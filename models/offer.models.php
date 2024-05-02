<?php

require_once "connections/connection.php";


class  ModelOffer{
    static public function showUser(){
        $sap_database = $_ENV['DB_DATABASE_SAP'];
        $stmt = Connection::conectsap()->prepare("SELECT  
                                                    Distinct (T0.\"CardCode\") \"CardCode\", 
                                                    T0.\"CardName\",
                                                    T0.\"ListNum\", 
                                                    T0.\"LicTradNum\",
                                                    T0.\"ShipToDef\",
                                                    IFNULL(T0.\"U_EstadoCredito\",'C') AS \"U_EstadoCredito\",
                                                    T0.\"ListNum\",
                                                    T0.\"GroupNum\" AS \"ConditionClient\",
                                                    T1.\"PymntGroup\" AS \"Nameconditionemployer\"
                                                    FROM {$sap_database}.OCRD T0 
                                                    INNER JOIN {$sap_database}.OCTG T1 ON T1.\"GroupNum\" = T0.\"GroupNum\"  
                                                    WHERE T0.\"CardType\" ='C'
                                                    ORDER BY T0.\"CardCode\" ");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function showDirectionForUser($cardcode){
        $sap_database = $_ENV['DB_DATABASE_SAP'];
        $stmt = Connection::conectsap()->prepare("SELECT 
                                                    T1.\"Address\",
                                                    ifNull( T1.\"Street\", ' ') \"Street\",
                                                    ifNull(T1.\"Block\",' ') \"Block\", 
                                                    ifNull(T1.\"ZipCode\",' ') \"ZipCode\", 
                                                    ifNull(T1.\"City\",' ') \"City\",
                                                    ifNull(T1.\"Country\",' ') \"Country\", 
                                                    ifNull(T1.\"State\",' ') \"State\", 
                                                    ifNull(T0.\"BillToDef\",' ') \"BillToDef\", 
                                                    ifNull(T0.\"ShipToDef\",' ') \"ShipToDef\"  
                                                    FROM {$sap_database}.OCRD T0 
                                                    INNER JOIN {$sap_database}.CRD1 T1 ON T0.\"CardCode\" = T1.\"CardCode\" 
                                                    WHERE T0.\"CardCode\" ='{$cardcode}' AND T1.\"Address\" NOT LIKE '%A%'");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function genericrfc(){
        $stmt = Connection::conect()->prepare("SELECT id, idsap, name  FROM `genericrfc`");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }
    
    static public function paymentcondition(){
        $sap_database = $_ENV['DB_DATABASE_SAP'];
        $stmt = Connection::conectsap()->prepare("SELECT 
                                                    \"GroupNum\" AS \"idsap\", 
                                                    \"PymntGroup\" As \"name\"
                                                    FROM {$sap_database}.\"OCTG\"
                                                ");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }
    
    static public function paymentmethods(){
        $stmt = Connection::conect()->prepare("SELECT id, idsap, name  FROM `paymentmethods`");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function wharehouse(){
        $sap_database = $_ENV['DB_DATABASE_SAP'];
        $stmt = Connection::conectsap()->prepare("SELECT 
                                                \"WhsCode\" AS \"idsap\", 
                                                ifNull(\"WhsName\",' ') AS \"name\" 
                                                FROM {$sap_database}.\"OWHS\" 
                                                WHERE \"WhsCode\" not like '%NV%'
                                                AND \"WhsName\" IS NOT NULL 
                                                ORDER BY \"WhsCode\" 
                                                ");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function paymentformath(){
        $sap_database = $_ENV['DB_DATABASE_SAP'];
        $stmt = Connection::conectsap()->prepare("SELECT 
                                                        \"PayMethCod\" AS \"idsap\",
                                                        \"Descript\" AS \"value\"
                                                        FROM {$sap_database}.OPYM
                                                        WHERE \"Type\" = 'I'
                                                ");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function routes(){
        $sap_database = $_ENV['DB_DATABASE_SAP'];
        $stmt = Connection::conectsap()->prepare("SELECT 
                                                  DISTINCT(T1.\"FldValue\") AS \"idsap\", 
                                                  T1.\"Descr\" AS \"value\"
                                                  FROM {$sap_database}.CUFD T0
                                                  INNER JOIN {$sap_database}.UFD1 T1 ON T1.\"FieldID\" = T0.\"FieldID\"
                                                  WHERE T0.\"AliasID\" = 'Ruta' 
                                                  AND T0.\"TableID\" = 'OQUT'");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function linesForDocEntry($DocEntry){
        $sap_database = $_ENV['DB_DATABASE_SAP'];
        $stmt = Connection::conectsap()->prepare("SELECT 
                                                    T0.\"DocEntry\",
                                                    T0.\"CardCode\",
                                                    T0.\"Comments\",
                                                    T0.\"PeyMethod\",
		                                            T0.\"GroupNum\" As \"PayMenthCond\",
                                                    T0.\"U_RFCondiciones\",
                                                    t0.\"U_MetodoPago\",
                                                    (T1.\"LineNum\" + 1) AS \"id\",
                                                    T1.\"LineNum\",
                                                    T1.\"LineStatus\",
                                                    T1.\"ItemCode\",
                                                    T1.\"Dscription\" AS \"ItemName\",
                                                    T1.\"Quantity\",
                                                    T1.\"OpenQty\",
                                                    T1.\"Price\",
                                                    T1.\"DiscPrcnt\",
                                                    T1.\"LineTotal\", 
                                                    T1.\"WhsCode\",
                                                    T1.\"SlpCode\",
                                                    T1.\"CodeBars\",
                                                    T2.\"ListNum\",
                                                    T1.\"TaxCode\"
                                                    FROM {$sap_database}.OQUT T0
                                                    INNER JOIN {$sap_database}.QUT1 T1 ON T1.\"DocEntry\" = T0.\"DocEntry\"
                                                    INNER JOIN {$sap_database}.OCRD T2 ON T2.\"CardCode\" = T0.\"CardCode\"
                                                    WHERE T0.\"DocEntry\" = {$DocEntry}");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function productSAP($pricelist,$warehouse){
        $sap_database = $_ENV['DB_DATABASE_SAP'];
        $stmt = Connection::conectsap()->prepare("SELECT 
                                                        T0.\"ItemCode\", 
                                                        T0.\"CodeBars\", 
                                                        T0.\"ItemName\",
                                                        IFNULL(T2.\"Price\",0) \"Price\",
                                                        T0.\"WTLiable\",
                                                        T1.\"OnHand\", 
                                                        T1.\"IsCommited\",
                                                        (T1.\"OnHand\" - T1.\"IsCommited\") \"Stock\"
                                                        FROM {$sap_database}.\"OITM\" T0  
                                                        INNER JOIN {$sap_database}.\"OITW\" T1 ON T0.\"ItemCode\" = T1.\"ItemCode\" 
                                                        INNER JOIN {$sap_database}.\"ITM1\" T2 ON T0.\"ItemCode\" = T2.\"ItemCode\"
                                                         WHERE  T2.\"PriceList\" ='{$pricelist}' AND T0.\"CodeBars\" is not null AND T1.\"WhsCode\"='{$warehouse}'");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function alloffer($start,$finish,$salePerson){
        $sap_database = $_ENV['DB_DATABASE_SAP'];
        if($salePerson == 0) $stmt = Connection::conectsap()->prepare("SELECT 
        CASE
        WHEN T0.\"DocStatus\" = 'O' THEN 'Abierta'
        WHEN T0.\"DocStatus\" = 'C' AND T0.\"CANCELED\" = 'N' THEN 'Cerrada'
        ELSE 'Cancelada'
        END AS \"Status\",
        T1.\"ListNum\",
        T0.\"DocEntry\", 
        T0.\"DocNum\",
        T0.\"DocType\",
        T0.\"SlpCode\",
        T0.\"DocDate\",
        T0.\"DocStatus\",
        T0.\"CANCELED\",
        T0.\"DocDueDate\",
        T0.\"CardCode\",
        T0.\"CardName\",
        T0.\"VatSum\" AS \"TotalTax\",
        T0.\"DocTotal\",
        T0.\"GroupNum\",
        T0.\"U_RFCondiciones\",
        T0.\"U_MetodoPago\",
        T0.\"U_MetodoPago\",
        T0.\"U_Sucursal\",
        T0.\"TaxDate\",
        T0.\"ShipToCode\",
        T0.\"LicTradNum\",
        T0.\"PeyMethod\"
        FROM {$sap_database}.OQUT
        INNER JOIN {$sap_database}.\"OCRD\" T1 ON T1.\"CardCode\" = T0.\"CardCode\" 
        WHERE T0\"DocDate\" BETWEEN '{$start}' AND '{$finish}'
        ");
        else $stmt = Connection::conectsap()->prepare("SELECT 
                                                        CASE
                                                        WHEN T0.\"DocStatus\" = 'O' THEN 'Abierta'
                                                        WHEN T0.\"DocStatus\" = 'C' AND T0.\"CANCELED\" = 'N' THEN 'Cerrada'
                                                        ELSE 'Cancelada'
                                                        END AS \"Status\",
                                                        T0.\"DocTime\",
                                                        T0.\"DocEntry\", 
                                                        T0.\"DocNum\",
                                                        T0.\"DocType\",
                                                        T0.\"SlpCode\",
                                                        T0.\"DocDate\",
                                                        T0.\"DocStatus\",
                                                        T0.\"CANCELED\",
                                                        T0.\"DocDueDate\",
                                                        T0.\"CardCode\",
                                                        T0.\"CardName\",
                                                        T0.\"VatSum\" AS \"TotalTax\",
                                                        T0.\"DocTotal\",
                                                        T0.\"TaxDate\",
                                                        T0.\"ShipToCode\",
                                                        T0.\"LicTradNum\",
                                                        T0.\"PeyMethod\",
                                                        T0.\"GroupNum\",
                                                        T0.\"U_RFCondiciones\",
                                                        T0.\"U_MetodoPago\",
                                                        T0.\"U_MetodoPago\",
                                                        T0.\"U_Sucursal\",
                                                        T1.\"U_EstadoCredito\",
                                                        T1.\"ListNum\",
                                                        T1.\"GroupNum\" AS \"ConditionClient\",
                                                        T2.\"PymntGroup\" AS \"Nameconditionemployer\"
                                                        FROM {$sap_database}.OQUT T0
                                                        INNER JOIN {$sap_database}.OCRD T1 ON T1.\"CardCode\" = T0.\"CardCode\"
                                                        INNER JOIN {$sap_database}.OCTG T2 ON T2.\"GroupNum\" = T1.\"GroupNum\" 
                                                        WHERE T0.\"DocDate\" BETWEEN '{$start}' AND '{$finish}'
                                                        AND T0.\"SlpCode\" = '{$salePerson}'");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function createQueue(){
        $mysql = Connection::conect();
        $stmt = $mysql->prepare("INSERT INTO `queueorder` (`id`, `status`) VALUES (NULL, 'awaiting')");
        if($stmt->execute()) return $mysql->lastInsertId();
        else messageErrorCode($mysql->errorInfo(),200);
        // $stmt->close();
        $stmt=null;
    }

    static public function getAQueue($key){
        $stmt = Connection::conect()->prepare("SELECT * FROM `queueorder` WHERE `id` = '{$key}'");
        
        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function patchAQueue($key, $status){
        $stmt = Connection::conect()->prepare("UPDATE `queueorder` SET `status`='{$status}' WHERE `id` = '{$key}'");
        

        if($stmt->execute()) return array("status"=>"success");
        else messageErrorCode(Connection::conect()->errorInfo(),200);

        // $stmt->close();

        $stmt=null;
    }
}