<?php

require_once "connections/connection.php";

class  ModelApprovalRequest{
    static public function WareHouseSN($CardCode,$Warehouse){
        $sap_database = $_ENV['DB_DATABASE_SAP'];
        $stmt = Connection::conectsap()->prepare("SELECT 
                                                CASE
                                                WHEN IFNULL(\"U_Almacen\",'01') != '{$Warehouse}' 
                                                AND \"U_Interempresa\" = 'N'  THEN true
                                                else false
                                                END AS \"validation\"
                                                FROM {$sap_database}.\"OCRD\" 
                                                WHERE \"CardCode\" = '{$CardCode}'");
        
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC)[0];

        $stmt=null;
    }

    static public function Counted($CardCode,$GroupNum){
        $sap_database = $_ENV['DB_DATABASE_SAP'];
        $stmt = Connection::conectsap()->prepare("SELECT 
                                                CASE
                                                WHEN \"U_Interempresa\" = 'N' AND {$GroupNum} = '2'
                                                THEN true
                                                else false
                                                END AS \"validation\"
                                                FROM {$sap_database}.\"OCRD\" 
                                                WHERE \"CardCode\" = '{$CardCode}'");
        
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC)[0];

        $stmt=null;
    }

    static public function CountedCC($CardCode){
        $sap_database = $_ENV['DB_DATABASE_SAP'];
        $stmt = Connection::conectsap()->prepare("SELECT 
                                                CASE
                                                WHEN \"U_EstadoCredito\" = 'C' THEN true
                                                else false
                                                END AS \"validation\"
                                                FROM {$sap_database}.\"OCRD\" 
                                                WHERE \"CardCode\" = '{$CardCode}'");
        
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC)[0];

        $stmt=null;
    }

    static public function Credit($CardCode){
        $sap_database = $_ENV['DB_DATABASE_SAP'];
        $stmt = Connection::conectsap()->prepare("SELECT 
                                                IFNULL(\"U_Interempresa\",'N') as \"U_Interempresa\",
                                                IFNULL(\"CreditLine\",0) as \"U_CreditLine\",
                                                IFNULL((\"Balance\" + \"OrdersBal\"),0) as \"U_SaldoD\",
                                                IFNULL((SELECT SUM (\"BalDueDeb\") FROM {$sap_database}.JDT1 T0 WHERE \"ShortName\" = '{$CardCode}' AND  \"DueDate\"  <=  CURRENT_TIMESTAMP),0) as \"U_SaldoVenSN\"
                                                FROM {$sap_database}.\"OCRD\"
                                                WHERE \"CardCode\" = '{$CardCode}'");
        
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC)[0];

        $stmt=null;
    }

    static public function CreditValidation($validation, $total, $GroupNum){
        $stmt = Connection::conectsap()->prepare("SELECT 
                                                    CASE
                                                    WHEN ('{$validation['U_Interempresa']}' = 'N' 
                                                    AND '{$GroupNum}' <> '2' 
                                                    AND ({$validation['U_SaldoD']} > {$validation['U_CreditLine']} 
                                                    OR {$validation['U_SaldoVenSN']} > 1 
                                                    OR ({$validation['U_CreditLine']} - {$validation['U_SaldoD']}) < {$total}))
                                                    THEN true
                                                    ELSE false
                                                    END AS \"validation\"
                                                    FROM DUMMY");
        
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC)[0];

        $stmt=null;
    }
}