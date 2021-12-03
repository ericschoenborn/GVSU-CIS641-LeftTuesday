using LeftTuesday.Models;
using System;
using System.Collections.Generic;

namespace LeftTuesday.Repository
{
    public class ContentRepository
    {
        public (Exception, List<Content>) GetContents()
        {
            var cmdString = @$"Select * From content;";
            return SqlHelper.QueryMany<Content>(cmdString);
        }


        public (Exception, Content) GetContent(int contentId)
        {
            var cmdString = @$"Select * From content WHERE id = {contentId}";
            return SqlHelper.QuerySingle<Content>(cmdString);
        }

        public (Exception, long) AddContent(Content content)
        {
            var cmdString = @$"INSERT INTO content
                                (type,value) 
                               VALUES
                                ('{content.Type}','{content.Value}')
                               ;SELECT LAST_INSERT_ID();";

            return SqlHelper.Insert(cmdString);
        }

        public (Exception, Content) UpdateContent(Content content)
        {
            var cmdString = @$"UPDATE content
                                SET type='{content.Type}',
                                value='{content.Value}'
                                WHERE id='{content.Id}';";

            return (SqlHelper.NonQuery(cmdString), content);
        }

        public (Exception, bool) DeleteContent(int id)
        {
            var cmdString = @$"DELETE FROM content WHERE id ={id}";
            return (SqlHelper.NonQuery(cmdString), true);
        }
    }
}
