using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Repository
{
    public class InitializeRepository
    {
        public Exception EnsureDatabase()
        {
            var cmdString = "CREATE DATABASE IF NOT EXISTS lefttuesday";
            return SqlHelper.NonQuery(cmdString);
        }

        public Exception EnsureUserTable()
        {
            var cmdString = @"CREATE TABLE IF NOT EXISTS `user` (
                  `id` int(11) NOT NULL auto_increment,       
                  `name` varchar(50) NOT NULL default '',
                  `secret` varchar(400) NOT NULL default '', 
                  `created` DATETIME DEFAULT CURRENT_TIMESTAMP,     
                   PRIMARY KEY(`id`)
                ); ";
            return SqlHelper.NonQuery(cmdString);
        }

        public Exception EnsureConceptTable()
        {
            var cmdString = @"CREATE TABLE IF NOT EXISTS `concept` (
                  `id` int(11) NOT NULL auto_increment,       
                  `name` varchar(50)  NOT NULL default '',
                  `description` varchar(50)  NOT NULL default '',
                  `created` DATETIME DEFAULT CURRENT_TIMESTAMP,     
                   PRIMARY KEY(`id`)
                ); ";
            return SqlHelper.NonQuery(cmdString);
        }

        public Exception EnsureTaskTable()
        {
            var cmdString = @"CREATE TABLE IF NOT EXISTS `task` (
                  `id` int(11) NOT NULL auto_increment,       
                  `name` varchar(50)  NOT NULL default '',
                  `description` varchar(50)  NOT NULL default '',
                  `created` DATETIME DEFAULT CURRENT_TIMESTAMP,     
                   PRIMARY KEY(`id`)
                ); ";
            return SqlHelper.NonQuery(cmdString);
        }

        public Exception EnsureContentTable()
        {
            var cmdString = @"CREATE TABLE IF NOT EXISTS `content` (
                  `id` int(11) NOT NULL auto_increment,       
                  `type` int(11)  NOT NULL default 0,
                  `value` varchar(500)  NOT NULL default '',
                  `created` DATETIME DEFAULT CURRENT_TIMESTAMP,     
                   PRIMARY KEY(`id`)
                ); ";
            return SqlHelper.NonQuery(cmdString);
        }

        public Exception EnsureTaskContentTable()
        {
            var cmdString = @"CREATE TABLE IF NOT EXISTS `task_content` (
                  `id` int(11) NOT NULL auto_increment,                         
                  `task` int(11) NOT NULL,
                  `content` int(11) NOT NULL,
                   PRIMARY KEY(`id`)
                ); ";
            return SqlHelper.NonQuery(cmdString);
        }

        public Exception EnsureConceptTaskTable()
        {
            var cmdString = @"CREATE TABLE IF NOT EXISTS `concept_task` (
                  `id` int(11) NOT NULL auto_increment,       
                  `concept` int(11) NOT NULL,
                  `task` int(11) NOT NULL,
                   PRIMARY KEY(`id`)
                ); ";
            return SqlHelper.NonQuery(cmdString);
        }

        public Exception EnsureSessionTable()
        {
            var cmdString = @"CREATE TABLE IF NOT EXISTS `session` (
                  `id` int(11) NOT NULL auto_increment,       
                  `name` varchar(20)  NOT NULL default '',
                  `concept` int(11) NOT NULL,
                  `description` varchar(50)  NOT NULL default '',
                  `start` DATETIME DEFAULT CURRENT_TIMESTAMP,
                  `end` DATETIME NOT NULL,
                  `created` DATETIME DEFAULT CURRENT_TIMESTAMP,     
                   PRIMARY KEY(`id`)
                ); ";
            return SqlHelper.NonQuery(cmdString);
        }

        public Exception EnsureSessionLeaderTable()
        {
            var cmdString = @"CREATE TABLE IF NOT EXISTS `session_leader` (
                  `id` int(11) NOT NULL auto_increment,       
                  `session` int(11) NOT NULL,
                  `leader` int(11) NOT NULL,
                   PRIMARY KEY(`id`)
                ); ";
            return SqlHelper.NonQuery(cmdString);
        }

        public Exception EnsureSessionParticipantTable()
        {
            var cmdString = @"CREATE TABLE IF NOT EXISTS `session_participant` (
                  `id` int(11) NOT NULL auto_increment,       
                  `session` int(11) NOT NULL,
                  `participant` int(11) NOT NULL,
                   PRIMARY KEY(`id`)
                ); ";
            return SqlHelper.NonQuery(cmdString);
        }

        public Exception EnsureConceptOwnerTable()
        {
            var cmdString = @"CREATE TABLE IF NOT EXISTS `concept_owner` (
                  `id` int(11) NOT NULL auto_increment,       
                  `concept` int(11) NOT NULL,
                  `owner` int(11) NOT NULL,
                   PRIMARY KEY(`id`)
                ); ";
            return SqlHelper.NonQuery(cmdString);
        }

        public Exception EnsureCompletedTaskTable()
        {
            var cmdString = @"CREATE TABLE IF NOT EXISTS `completed_task` (
                  `id` int(11) NOT NULL auto_increment,       
                  `session` int(11) NOT NULL,
                  `participant` int(11) NOT NULL,
                  `task` int(11) NOT NULL,
                  `created` DATETIME DEFAULT CURRENT_TIMESTAMP,
                   PRIMARY KEY(`id`)
                ); ";
            return SqlHelper.NonQuery(cmdString);
        }
    }
}
