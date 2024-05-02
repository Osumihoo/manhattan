<?php

require_once "connections/connection.php";


class  ModelShopOffer{
    static public function supplier(){
        $sap_database = $_ENV['DB_DATABASE_SAP'];
        $stmt = Connection::conectsap()->prepare("SELECT  
                                                    Distinct (T0.\"CardCode\") \"CardCode\", 
                                                    T0.\"CardName\",
                                                    T0.\"ListNum\",
                                                    T0.\"LicTradNum\"
                                                    FROM {$sap_database}.OCRD T0  
                                                    WHERE T0.\"CardType\" ='S'
                                                    ORDER BY T0.\"CardCode\" ");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function showDirectionForUser(){
        $sap_database = $_ENV['DB_DATABASE_SAP'];
        $stmt = Connection::conectsap()->prepare("SELECT 
                                                    ifNull(\"StreetS\", ' ') \"Street\",
                                                    ifNull(\"BlockS\",' ') \"Block\", 
                                                    ifNull(\"ZipCodeS\",' ') \"ZipCode\", 
                                                    ifNull(\"CityS\",' ') \"City\",
                                                    ifNull(\"CountryS\",' ') \"Country\", 
                                                    ifNull(\"StateS\",' ') \"State\"
                                                    FROM {$sap_database}.PQT12
                                                    LIMIT 1");

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
                                                ");

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
                                                    T0.\"U_MetodoPago\",
                                                    T0.\"DocDueDate\",
                                                    T0.\"ReqDate\",
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
                                                    FROM {$sap_database}.OPQT T0
                                                    INNER JOIN {$sap_database}.PQT1 T1 ON T1.\"DocEntry\" = T0.\"DocEntry\"
                                                    INNER JOIN {$sap_database}.OCRD T2 ON T2.\"CardCode\" = T0.\"CardCode\"
                                                    WHERE T0.\"DocEntry\" = {$DocEntry}");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function productSAP($pricelist,$warehouse,$cardcode){
        $sap_database = $_ENV['DB_DATABASE_SAP'];
        $stmt = Connection::conectsap()->prepare("SELECT 
                                                    T0.\"ItemCode\", 
                                                    T0.\"CardCode\", 
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
                                                    WHERE T2.\"PriceList\" ='{$pricelist}' 
                                                    AND T0.\"CodeBars\" is not null 
                                                    AND T1.\"WhsCode\"='{$warehouse}'
                                                    AND T0.\"CardCode\" = '{$cardcode}'");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function alloffer($start,$finish,$salePerson){
        $sap_database = $_ENV['DB_DATABASE_SAP'];
        if($salePerson == 0) $stmt = Connection::conectsap()->prepare("SELECT 
        CASE
        WHEN \"DocStatus\" = 'O' THEN 'Abierta'
        WHEN \"DocStatus\" = 'C' AND \"CANCELED\" = 'N' THEN 'Cerrada'
        ELSE 'Cancelada'
        END AS \"Status\",
        \"DocEntry\", 
        \"DocNum\",
        \"DocType\",
        \"SlpCode\",
        \"DocDate\",
        \"DocStatus\",
        \"CANCELED\",
        \"DocDueDate\",
        \"CardCode\",
        \"CardName\",
        \"VatSum\" AS \"TotalTax\",
        \"DocTotal\",
        \"TaxDate\",
        \"ShipToCode\",
        \"LicTradNum\",
        \"PeyMethod\"
        FROM {$sap_database}.OQUT
        WHERE \"DocDate\" BETWEEN '{$start}' AND '{$finish}'
        ");
        else $stmt = Connection::conectsap()->prepare("SELECT 
                                                        CASE
                                                        WHEN T0.\"DocStatus\" = 'O' THEN 'Abierta'
                                                        WHEN T0.\"DocStatus\" = 'C' AND T0.\"CANCELED\" = 'N' THEN 'Cerrada'
                                                        ELSE 'Cancelada'
                                                        END AS \"Status\",
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
                                                        T1.\"U_EstadoCredito\",
                                                        T1.\"GroupNum\" AS \"ConditionClient\",
                                                        T2.\"PymntGroup\" AS \"Nameconditionemployer\"
                                                        FROM {$sap_database}.OPQT T0
                                                        INNER JOIN {$sap_database}.OCRD T1 ON T1.\"CardCode\" = T0.\"CardCode\"
                                                        INNER JOIN {$sap_database}.OCTG T2 ON T2.\"GroupNum\" = T1.\"GroupNum\" 
                                                        WHERE T0.\"DocDate\" BETWEEN '{$start}' AND '{$finish}'
                                                        AND T0.\"SlpCode\" = '{$salePerson}'");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }
}