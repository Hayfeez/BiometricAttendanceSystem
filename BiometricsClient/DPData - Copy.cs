using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DPFP.ID;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using static BiometricsClient.ErrorLogBase;
using System.Collections.ObjectModel;

namespace BiometricsClient.Copy
{
   

    sealed class DPData
    {
        public DPData()
        {
        }

        public static Database Database;
    }

    public class Record
    {
        // private fields
        private string m_ID;
        private DPFP.Template m_Template;

        public Record(string id, DPFP.Template template)
        {
            if (id != null & template != null)
            {
                m_ID = id;
                m_Template = template;
            }
            else
                throw new ArgumentException("Valid Record");
        }

        public DPFP.Template Template
        {
            get
            {
                return m_Template;
            }
        }

        public string ID
        {
            get
            {
                return m_ID;
            }
        }
    }

    public class Database : IDisposable
    {
        private bool disposedValue = false;        // To detect redundant calls

        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (!this.disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: free other state (managed objects).
                        if (Connection != null)
                        {
                            if (Connection.State != ConnectionState.Closed)
                                Connection.Close();
                            Connection.Dispose();
                            Connection = null;
                        }
                    }
                }
                this.disposedValue = true;
            }
            catch (Exception ex)
            {
                try
                {
                    logger.WriteLog(ex);
                }
                catch (Exception exx)
                {
                }
            }
        }

        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // variables---------------------------------
        private RecordCollection m_records;
        private SqlConnection Connection;
        // -------------------------------------------

        public RecordCollection Records
        {
            get
            {
                return m_records;
            }
        }

        public DPFP.ID.UserCollection RecordsWithIdentity
        {
            get
            {
                return m_records.UserCollections;
            }
        }
        private string _ConnectionString;
        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
        }
        internal Database(string ConnectionString, string FingerTable, bool UseIdentityProcess = false, bool AutoLoadData = true, string LoadSQL = "")
        {
            try
            {
                _ConnectionString = ConnectionString;
                Connection = new SqlConnection(ConnectionString);
                Connection.Open();
                m_records = new RecordCollection(this, FingerTable, UseIdentityProcess, AutoLoadData, LoadSQL);
            }
            catch (Exception ex)
            {
                try
                {
                    logger.WriteLog(ex);
                }
                catch (Exception exx)
                {
                }
                throw new Exception("Error Reaching Database");
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }

        internal Database(DataTable dt, bool UseIdentityProcess = false)
        {
            try
            {
                m_records = new RecordCollection(this, dt, UseIdentityProcess);
            }
            catch (Exception ex)
            {
                try
                {
                    logger.WriteLog(ex);
                }
                catch (Exception exx)
                {
                }
                throw new Exception("Error Reaching Database");
            }
            finally
            {
            }
        }


        public class RecordCollection : ReadOnlyCollection<Record>
        {
            private List<Record> itmG;
            private Database owner;
            private DPFP.ID.UserCollection UserCollection = new DPFP.ID.UserCollection(500000);
            private string FTable;
            private bool UseIdentityProcess;
            public UserCollection UserCollections
            {
                get
                {
                    return UserCollection;
                }
            }

            public RecordCollection(Database Owner, DataTable dt, bool _UseIdentityProcess = false) : base(new List<Record>())
            {
                UseIdentityProcess = _UseIdentityProcess;
                try
                {
                    if (!UseIdentityProcess)
                    {
                        itmG = new List<Record>(255);
                        string id;
                        Record record;
                        foreach (DataRow reader in dt.Rows)
                        {
                            id = reader["FingerID"].ToString();
                            MemoryStream memStreamTemplate = new MemoryStream((byte[])reader["Features"]);
                            DPFP.Template template = new DPFP.Template();
                            template.DeSerialize(memStreamTemplate);

                            record = new Record(id, template);
                            Items.Add(record);
                        }
                    }
                    else
                    {
                        string CurrentID = "";
                        string PreviousID = "";
                        DPFP.ID.User Usr;
                        Int16 Fingerposition = 0;
                        DPFP.Template template = new DPFP.Template();
                        string id;

                        foreach (DataRow reader in dt.Rows)
                        {
                            id = reader["FingerID"].ToString();
                            if (string.IsNullOrEmpty(id.Trim()))
                                continue;
                            CurrentID = id;

                            MemoryStream memStreamTemplate = new MemoryStream((byte[])reader["Features"]);
                            template.DeSerialize(memStreamTemplate);

                            if (PreviousID != CurrentID & PreviousID != "")
                            {   Usr = new User(CurrentID);
                                UserCollection.AddUser(ref Usr);
                                Fingerposition = 0;
                            }

                            if (PreviousID != CurrentID)
                                Usr = new DPFP.ID.User(id);

                            Usr.AddTemplate(template, (FingerPosition)Fingerposition);

                            PreviousID = id;
                            Fingerposition += 1;
                        }

                        if (Usr != null)
                            UserCollection.AddUser(ref Usr);
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                }

                finally
                {
                }
            }


            public RecordCollection(Database Owner, string FingerTable, bool _UseIdentityProcess = false, bool AutoLoadData = true, string LoadSql = "") : base(new List<Record>())
            {
                SqlCommand cmd;
                SqlDataReader reader;
                UseIdentityProcess = _UseIdentityProcess;
                try
                {
                    FTable = FingerTable;
                    if (AutoLoadData)
                    {
                        if (!UseIdentityProcess)
                        {
                            itmG = new List<Record>(255);
                            this.owner = Owner;
                            if (LoadSql == "")
                                LoadSql = "select  Features, FingerID  from " + FingerTable + "  order by fingerID";
                            cmd = new SqlCommand(LoadSql, Owner.Connection);
                            cmd.CommandTimeout = 0;
                            reader = cmd.ExecuteReader(CommandBehavior.Default);
                            string id;
                            Record record;
                            while (reader.Read())
                            {
                                id = reader["FingerID"].ToString();
                                MemoryStream memStreamTemplate = new MemoryStream((byte[])reader["Features"]);
                                DPFP.Template template = new DPFP.Template();
                                template.DeSerialize(memStreamTemplate);

                                record = new Record(id, template);
                                Items.Add(record);
                            }
                        }
                        else
                        {
                            // -----------------------------------------------'----------------------------------------------- 
                            if (LoadSql == "")
                                LoadSql = "select  Features, FingerID  from " + FingerTable + "  order by fingerID";

                            if (!LoadSql.ToLower().Contains(" order "))
                                LoadSql += " order by fingerID";

                            cmd = new SqlCommand(LoadSql, Owner.Connection);

                            cmd.CommandTimeout = 0;
                            string CurrentID = "";
                            string PreviousID = "";
                            reader = cmd.ExecuteReader(CommandBehavior.Default);
                            DPFP.ID.User Usr = new User("");
                            Int16 Fingerposition = 0;
                            DPFP.Template template = new DPFP.Template();
                            string id;

                            while (reader.Read())
                            {
                                id = reader["FingerID"].ToString();
                                if (string.IsNullOrEmpty(id.Trim()))
                                    continue;
                                CurrentID = id;

                                MemoryStream memStreamTemplate = new MemoryStream((byte[])reader["Features"]);
                                template.DeSerialize(memStreamTemplate);

                                if (PreviousID != CurrentID & PreviousID != "")
                                {
                                    UserCollection.AddUser(ref Usr);
                                    Fingerposition = 0;
                                }

                                if (PreviousID != CurrentID)
                                    Usr = new DPFP.ID.User(id);

                                Usr.AddTemplate(template, (FingerPosition)Fingerposition);

                                PreviousID = id;
                                Fingerposition += 1;
                            }
                            if (Usr != null)
                                UserCollection.AddUser(ref Usr);
                        }
                        cmd.Dispose();
                    }
                }
                catch (Exception ex)
                {                  
                   logger.WriteLog(ex);
                    
                }

            }

            public void GetAllFingerprintsAgain(string FingerTable)
            {
                Items.Clear();
                SqlConnection sqlcon = new SqlConnection(DPData.Database.ConnectionString);
                SqlCommand cmd;
               
                sqlcon.Open();
                try
                {
                    SqlDataReader reader;
                    if (!UseIdentityProcess)
                    {
                        cmd = new SqlCommand("Select Features, FingerID from " + FingerTable + " " + " ", sqlcon);

                        cmd.CommandTimeout = 0;
                        reader = cmd.ExecuteReader(CommandBehavior.Default);
                        while (reader.Read())
                        {
                            string id = reader["FingerID"].ToString();
                            DPFP.Template template = new DPFP.Template();
                            MemoryStream memStreamTemplate = new MemoryStream((byte[])reader["Features"]);
                            template.DeSerialize(memStreamTemplate);

                            Record record = new Record(id, template);
                            Items.Add(record);
                        }
                    }
                    else
                    {
                        // -----------------------------------------------'----------------------------------------------- 
                        cmd = new SqlCommand("select  Features, FingerID  from fingerprints " + "  order by fingerID", sqlcon);

                        cmd.CommandTimeout = 0;
                        string CurrentID = "";
                        string PreviousID = "";
                        reader = cmd.ExecuteReader(CommandBehavior.Default);
                        DPFP.ID.User Usr;
                        Int16 Fingerposition = 0;
                        DPFP.Template template = new DPFP.Template();
                        string id;

                        while (reader.Read())
                        {
                            id = reader["FingerID"].ToString();
                            CurrentID = id;

                            MemoryStream memStreamTemplate = new MemoryStream((byte[])reader["Features"]);
                            template.DeSerialize(memStreamTemplate);

                            if (PreviousID != CurrentID & PreviousID != "")
                            {
                                UserCollection.AddUser(ref Usr);
                                Fingerposition = 0;
                            }

                            if (PreviousID != CurrentID)
                                Usr = new DPFP.ID.User(id);

                            Usr.AddTemplate(template, (FingerPosition)Fingerposition);

                            PreviousID = id;
                            Fingerposition += 1;
                        }
                        if (Usr != null)
                            UserCollection.AddUser(ref Usr);

                        cmd.Dispose();
                    }
                }
                catch (Exception ex)
                {
                     logger.WriteLog(ex);
                   
                }
            }

            public void Add(string ID, DPFP.Template template, byte[] picture, string FIngerTable, Int16 Dpi = 700)
            {
                SqlConnection sqlcon = new SqlConnection(DPData.Database.ConnectionString);
                try
                {
                    string InsertStatement = "Insert into " + FIngerTable + " (Features, FingerID,Picture ) Values (@Features, @FingerID, @Pictures)";
                    // Connection = New SqlConnection(ConnectionString)
                    // Connection.Open()
                    // 'Dim Features As Byte() = DirectCast(template.Bytes, Byte())
                    // If owner.Connection Is Nothing Then
                    // owner .Connection =
                    // End If
                    sqlcon.Open();
                    SqlCommand InsertCommand = new SqlCommand(InsertStatement, sqlcon);
                    InsertCommand.Parameters.Add("@Features", SqlDbType.VarBinary).Value = template.Bytes;
                    InsertCommand.Parameters.Add("@FingerID", SqlDbType.VarChar).Value = ID;
                    InsertCommand.Parameters.Add("@Pictures", SqlDbType.VarBinary).Value = picture;

                    int cnt = InsertCommand.ExecuteNonQuery();
                    InsertCommand.Dispose();

                    if (UseIdentityProcess)
                    {
                    }
                    else
                    {
                        Record record = new Record(ID, template);
                        Items.Add(record);
                    }

                    //return true;
                }
                catch (SqlException seex)
                {
                    throw seex;
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    throw ex;
                }
                finally
                {
                    if (sqlcon.State == ConnectionState.Open)
                        sqlcon.Close();
                }
              //  return true;
            }

            public void ClearByID(string Id, string FingerTable, SqlConnection con)
            {
                try
                {
                    Record rec;
                    DataTable dt = new DataTable();

                    if (!UseIdentityProcess)
                        dt = GetTemplateByID(Id, con);

                    // delete from DB
                    SqlCommand cmd = new SqlCommand("DELETE FROM  " + FingerTable + " where FingerID='" + Id + "'", con);
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    con.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        // remove form the collection
                        if (UseIdentityProcess)
                        {
                            UserID UsrId = new UserID(Id);
                            UserCollections.RemoveUser(UsrId);
                        }
                        else if (dt != null)
                        {
                            var LItem = Items.ToList();
                            LItem.RemoveAll(x => x.ID == Id);
                            Items.Clear();
                            foreach (var itm in LItem)
                                Items.Add(itm);
                            LItem.Clear();
                        }
                        cmd.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    throw ex;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }

            private DataTable GetTemplateByID(string Id, SqlConnection Con)
            {
                SqlDataAdapter dd = new SqlDataAdapter("SELECT Features FROM  " + FTable + " where FingerID='" + Id + "'", Con);
                DataSet ds = new DataSet();
                try
                {
                    dd.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                        return ds.Tables[0];
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    throw ex;
                }
                return null/* TODO Change to default(_) if this is not a reference type */;
            }

            public DataTable GetFingerByID(string Id, SqlConnection con, string FingerTable)
            {
                SqlDataAdapter dd = new SqlDataAdapter("SELECT Picture FROM  " + FingerTable + " where FingerID='" + Id + "'", con);
                DataSet ds = new DataSet();
                try
                {
                    dd.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                        return ds.Tables[0];
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    throw ex;
                }
                return null/* TODO Change to default(_) if this is not a reference type */;
            }

            public bool HasFinger(string Id, SqlConnection con, string FingerTable)
            {
                SqlDataAdapter dd = new SqlDataAdapter("SELECT FingerID FROM  " + FingerTable + " where FingerID='" + Id + "'", con);
                DataSet ds = new DataSet();
                bool status;
                try
                {
                    dd.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                        status = true;
                    else
                        status = false;
                    return status;
                }
                catch (Exception ex)
                {
                    try
                    {
                        logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    throw ex;
                }
            }
        }
    }

}
