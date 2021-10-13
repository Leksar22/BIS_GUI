using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApp2
{
    public partial class vmMainViewModel : INotifyPropertyChanged
    {
        private global::MySql.Data.MySqlClient.MySqlDataAdapter _adapterResults;
        private global::MySql.Data.MySqlClient.MySqlConnection Connection;
        private void InitAdapter_results()
        {
            this._adapterResults = new global::MySql.Data.MySqlClient.MySqlDataAdapter();
            global::System.Data.Common.DataTableMapping tableMapping = new global::System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "results";
            tableMapping.ColumnMappings.Add("cur_time", "cur_time");
            tableMapping.ColumnMappings.Add("P", "P");
            tableMapping.ColumnMappings.Add("dP", "dP");
            tableMapping.ColumnMappings.Add("T", "T");
            tableMapping.ColumnMappings.Add("Qm_water", "Qm_water");
            tableMapping.ColumnMappings.Add("Qm_oil", "Qm_oil");
            tableMapping.ColumnMappings.Add("Qv_air", "Qv_air");
            tableMapping.ColumnMappings.Add("comment", "comment");
            this._adapterResults.TableMappings.Add(tableMapping);
            global::MySql.Data.MySqlClient.MySqlParameter param = new global::MySql.Data.MySqlClient.MySqlParameter();


            // УДАЛЕНИЕ ДАННЫХ
            //
            //
            //this._adapterResults.DeleteCommand = new global::MySql.Data.MySqlClient.MySqlCommand();
            //this._adapterResults.DeleteCommand.Connection = this.Connection;
            //this._adapterResults.DeleteCommand.CommandText = "DELETE FROM `results` WHERE ((`cur_time` = @p1) AND (`P` = @p2) AND (`dP` = @p3) AND (`T` = @p4) AND (`Qm_water` = @p5) AND (`Qm_oil` = @p6) AND (`Qv_air` = @p7))";
            //this._adapterResults.DeleteCommand.CommandType = global::System.Data.CommandType.Text;

            //global::MySql.Data.MySqlClient.MySqlParameter param = new global::MySql.Data.MySqlClient.MySqlParameter();
            //param.ParameterName = "@p1";
            //param.DbType = global::System.Data.DbType.String;
            //param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.VarChar;
            //param.IsNullable = true;
            //param.SourceColumn = "cur_time";
            //param.SourceVersion = global::System.Data.DataRowVersion.Original;
            //this._adapterResults.DeleteCommand.Parameters.Add(param);

            //param = new global::MySql.Data.MySqlClient.MySqlParameter();
            //param.ParameterName = "@p2";
            //param.DbType = global::System.Data.DbType.Double;
            //param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            //param.IsNullable = true;
            //param.SourceColumn = "P";
            //param.SourceVersion = global::System.Data.DataRowVersion.Original;
            //this._adapterResults.DeleteCommand.Parameters.Add(param);

            //param = new global::MySql.Data.MySqlClient.MySqlParameter();
            //param.ParameterName = "@p3";
            //param.DbType = global::System.Data.DbType.Double;
            //param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            //param.IsNullable = true;
            //param.SourceColumn = "dP";
            //param.SourceVersion = global::System.Data.DataRowVersion.Original;
            //this._adapterResults.DeleteCommand.Parameters.Add(param);

            //param = new global::MySql.Data.MySqlClient.MySqlParameter();
            //param.ParameterName = "@p4";
            //param.DbType = global::System.Data.DbType.Double;
            //param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            //param.IsNullable = true;
            //param.SourceColumn = "T";
            //param.SourceVersion = global::System.Data.DataRowVersion.Original;
            //this._adapterResults.DeleteCommand.Parameters.Add(param);

            //param = new global::MySql.Data.MySqlClient.MySqlParameter();
            //param.ParameterName = "@p5";
            //param.DbType = global::System.Data.DbType.Double;
            //param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            //param.IsNullable = true;
            //param.SourceColumn = "Qm_water";
            //param.SourceVersion = global::System.Data.DataRowVersion.Original;
            //this._adapterResults.DeleteCommand.Parameters.Add(param);

            //param = new global::MySql.Data.MySqlClient.MySqlParameter();
            //param.ParameterName = "@p6";
            //param.DbType = global::System.Data.DbType.Double;
            //param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            //param.IsNullable = true;
            //param.SourceColumn = "Qm_oil";
            //param.SourceVersion = global::System.Data.DataRowVersion.Original;
            //this._adapterResults.DeleteCommand.Parameters.Add(param);

            //param = new global::MySql.Data.MySqlClient.MySqlParameter();
            //param.ParameterName = "@p7";
            //param.DbType = global::System.Data.DbType.Double;
            //param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            //param.IsNullable = true;
            //param.SourceColumn = "Qv_air";
            //param.SourceVersion = global::System.Data.DataRowVersion.Original;
            //this._adapterResults.DeleteCommand.Parameters.Add(param);


            // ВСТАВКА НОВЫХ ДАННЫХ
            //
            //
            //this._adapterResults.InsertCommand = new global::MySql.Data.MySqlClient.MySqlCommand();
            //this._adapterResults.InsertCommand.Connection = this.Connection;
            //this._adapterResults.InsertCommand.CommandText = "INSERT INTO `results` (`cur_time`, `P`, `dP`, `T`, `Qm_water`, `Qm_oil`, `Qv_air`) VALUES" +
            //    " (@p1, @p2, @p3, @p4, @p5, @p6, @p7)";
            //this._adapterResults.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            
            //param = new global::MySql.Data.MySqlClient.MySqlParameter();
            //param.ParameterName = "@p1";
            //param.DbType = global::System.Data.DbType.String;
            //param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.VarChar;
            //param.IsNullable = true;
            //param.SourceColumn = "cur_time";
            //param.SourceVersion = global::System.Data.DataRowVersion.Current;
            //this._adapterResults.InsertCommand.Parameters.Add(param);

            //param = new global::MySql.Data.MySqlClient.MySqlParameter();
            //param.ParameterName = "@p2";
            //param.DbType = global::System.Data.DbType.Double;
            //param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            //param.IsNullable = true;
            //param.SourceColumn = "P";
            //param.SourceVersion = global::System.Data.DataRowVersion.Current;
            //this._adapterResults.InsertCommand.Parameters.Add(param);

            //param = new global::MySql.Data.MySqlClient.MySqlParameter();
            //param.ParameterName = "@p3";
            //param.DbType = global::System.Data.DbType.Double;
            //param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            //param.IsNullable = true;
            //param.SourceColumn = "dP";
            //param.SourceVersion = global::System.Data.DataRowVersion.Current;
            //this._adapterResults.InsertCommand.Parameters.Add(param);

            //param = new global::MySql.Data.MySqlClient.MySqlParameter();
            //param.ParameterName = "@p4";
            //param.DbType = global::System.Data.DbType.Double;
            //param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            //param.IsNullable = true;
            //param.SourceColumn = "T";
            //param.SourceVersion = global::System.Data.DataRowVersion.Current;
            //this._adapterResults.InsertCommand.Parameters.Add(param);

            //param = new global::MySql.Data.MySqlClient.MySqlParameter();
            //param.ParameterName = "@p5";
            //param.DbType = global::System.Data.DbType.Double;
            //param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            //param.IsNullable = true;
            //param.SourceColumn = "Qm_water";
            //param.SourceVersion = global::System.Data.DataRowVersion.Current;
            //this._adapterResults.InsertCommand.Parameters.Add(param);


            //param = new global::MySql.Data.MySqlClient.MySqlParameter();
            //param.ParameterName = "@p6";
            //param.DbType = global::System.Data.DbType.Double;
            //param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            //param.IsNullable = true;
            //param.SourceColumn = "Qm_oil";
            //param.SourceVersion = global::System.Data.DataRowVersion.Current;
            //this._adapterResults.InsertCommand.Parameters.Add(param);

            //param = new global::MySql.Data.MySqlClient.MySqlParameter();
            //param.ParameterName = "@p7";
            //param.DbType = global::System.Data.DbType.Double;
            //param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            //param.IsNullable = true;
            //param.SourceColumn = "Qv_air";
            //param.SourceVersion = global::System.Data.DataRowVersion.Current;
            //this._adapterResults.InsertCommand.Parameters.Add(param);


            this._adapterResults.UpdateCommand = new global::MySql.Data.MySqlClient.MySqlCommand();
            this._adapterResults.UpdateCommand.Connection = this.Connection;
            this._adapterResults.UpdateCommand.CommandText = "UPDATE `results` SET `cur_time` = @p1, `P` = @p2, `dP` = @p3, `T` = @p4, `Qm_water` = @p5, `Qm_oil` = @p6, `Qv_air` = @p7, `comment` = @p_comment1" +
                " WHERE ((`cur_time` = @p8) AND (`P` = @p9) AND (`dP` = @p10) AND (`T` = @p11) AND (`Qm_water` = @p12) AND (`Qm_oil` = @p13) AND (`Qv_air` = @p14) AND (`comment` = @p_comment2 or `comment` is null))";
            this._adapterResults.UpdateCommand.CommandType = global::System.Data.CommandType.Text;

            param = new global::MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = "@p1";
            param.DbType = global::System.Data.DbType.String;
            param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.VarChar;
            param.IsNullable = true;
            param.SourceColumn = "cur_time";
            param.SourceVersion = global::System.Data.DataRowVersion.Current;
            this._adapterResults.UpdateCommand.Parameters.Add(param);

            param = new global::MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = "@p2";
            param.DbType = global::System.Data.DbType.Double;
            param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            param.IsNullable = true;
            param.SourceColumn = "P";
            param.SourceVersion = global::System.Data.DataRowVersion.Current;
            this._adapterResults.UpdateCommand.Parameters.Add(param);

            param = new global::MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = "@p3";
            param.DbType = global::System.Data.DbType.Double;
            param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            param.IsNullable = true;
            param.SourceColumn = "dP";
            param.SourceVersion = global::System.Data.DataRowVersion.Current;
            this._adapterResults.UpdateCommand.Parameters.Add(param);

            param = new global::MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = "@p4";
            param.DbType = global::System.Data.DbType.Double;
            param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            param.IsNullable = true;
            param.SourceColumn = "T";
            param.SourceVersion = global::System.Data.DataRowVersion.Current;
            this._adapterResults.UpdateCommand.Parameters.Add(param);

            param = new global::MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = "@p5";
            param.DbType = global::System.Data.DbType.Double;
            param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            param.IsNullable = true;
            param.SourceColumn = "Qm_water";
            param.SourceVersion = global::System.Data.DataRowVersion.Current;
            this._adapterResults.UpdateCommand.Parameters.Add(param);

            param = new global::MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = "@p6";
            param.DbType = global::System.Data.DbType.Double;
            param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            param.IsNullable = true;
            param.SourceColumn = "Qm_oil";
            param.SourceVersion = global::System.Data.DataRowVersion.Current;
            this._adapterResults.UpdateCommand.Parameters.Add(param);

            param = new global::MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = "@p7";
            param.DbType = global::System.Data.DbType.Double;
            param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            param.IsNullable = true;
            param.SourceColumn = "Qv_air";
            param.SourceVersion = global::System.Data.DataRowVersion.Current;
            this._adapterResults.UpdateCommand.Parameters.Add(param);

            param = new global::MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = "@p_comment1";
            param.DbType = global::System.Data.DbType.String;
            param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.VarChar;
            param.IsNullable = true;
            param.SourceColumn = "comment";
            param.SourceVersion = global::System.Data.DataRowVersion.Current;
            this._adapterResults.UpdateCommand.Parameters.Add(param);



            param = new global::MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = "@p8";
            param.DbType = global::System.Data.DbType.String;
            param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.VarChar;
            param.IsNullable = true;
            param.SourceColumn = "cur_time";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapterResults.UpdateCommand.Parameters.Add(param);

            param = new global::MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = "@p9";
            param.DbType = global::System.Data.DbType.Double;
            param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            param.IsNullable = true;
            param.SourceColumn = "P";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapterResults.UpdateCommand.Parameters.Add(param);

            param = new global::MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = "@p10";
            param.DbType = global::System.Data.DbType.Double;
            param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            param.IsNullable = true;
            param.SourceColumn = "dP";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapterResults.UpdateCommand.Parameters.Add(param);

            param = new global::MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = "@p11";
            param.DbType = global::System.Data.DbType.Double;
            param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            param.IsNullable = true;
            param.SourceColumn = "T";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapterResults.UpdateCommand.Parameters.Add(param);

            param = new global::MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = "@p12";
            param.DbType = global::System.Data.DbType.Double;
            param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            param.IsNullable = true;
            param.SourceColumn = "Qm_water";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapterResults.UpdateCommand.Parameters.Add(param);

            param = new global::MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = "@p13";
            param.DbType = global::System.Data.DbType.Double;
            param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            param.IsNullable = true;
            param.SourceColumn = "Qm_oil";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapterResults.UpdateCommand.Parameters.Add(param);

            param = new global::MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = "@p14";
            param.DbType = global::System.Data.DbType.Double;
            param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.Float;
            param.IsNullable = true;
            param.SourceColumn = "Qv_air";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapterResults.UpdateCommand.Parameters.Add(param);

            param = new global::MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = "@p_comment2";
            param.DbType = global::System.Data.DbType.String;
            param.MySqlDbType = global::MySql.Data.MySqlClient.MySqlDbType.VarChar;
            param.IsNullable = true;
            param.SourceColumn = "comment";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapterResults.UpdateCommand.Parameters.Add(param);
        }

        

    }

}
