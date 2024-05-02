<?php       
    class KeyServer{
        static public function StringConnection(){
            $DB_HOST = $_ENV['DB_HOST'];
            $DB_DATABASE = $_ENV['DB_DATABASE'];
            return "mysql:host={$DB_HOST};dbname={$DB_DATABASE}";
        }
        
        static public function StringUser(){
            $DB_USERNAME = $_ENV['DB_USERNAME'];
            return "{$DB_USERNAME}";
            
        }
    
        static public function StringPwd(){
            $DB_PASSWORD = $_ENV['DB_PASSWORD'];
            return "{$DB_PASSWORD}";
        }

        static public function StringConnectionSap(){
            $DB_HOST_SAP = $_ENV['DB_HOST_SAP'];
            $DB_DSN_SAP = $_ENV['DB_DSN_SAP'];
            return "{$DB_DSN_SAP}:{$DB_HOST_SAP}";
        }
        
        static public function StringUserSap(){
            $DB_USERNAME = $_ENV['DB_USERNAME_SAP'];
            return "{$DB_USERNAME}";
            
        }
    
        static public function StringPwdSap(){
            $DB_PASSWORD = $_ENV['DB_PASSWORD_SAP'];
            return "{$DB_PASSWORD}";
        }

    }