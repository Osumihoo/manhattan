<?php

require_once "connections/connection.php";

class  ModelSap{
    static public function showInvoices($start,$finish){
        $stmt = Connection::conectSap()->prepare("Select 
        Count (\"DocNum\")as \"cant\",
        \"CardCode\"
        from SB1CSL.\"OINV\"  
        where (\"DocStatus\"='C' OR \"DocStatus\"='O')
        and \"DocDate\" 
        BETWEEN '{$start}' and '{$finish} 23:59:59' and \"CANCELED\"!='Y'
        group by \"CardCode\",\"SlpCode\"");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function allInvoices($CardCode,$start,$finish){
        $stmt = Connection::conectSap()->prepare("select \"DocNum\" value,
        \"CardCode\",
         \"SlpCode\",
         \"DocDate\",
         \"DocStatus\"
         from SB1CSL.OINV 
         where (\"DocStatus\"='C' OR \"DocStatus\"='O') AND \"CardCode\"='{$CardCode}' and \"DocDate\" BETWEEN '{$start}' and '{$finish} 23:59:59' and \"CANCELED\"!='Y'");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function detailInvoices($invoice){
        $stmt = Connection::conectSap()->prepare("select 
        T1.\"ItemCode\",
        T1.\"Dscription\",
        T1.\"Quantity\",
        T1.\"PriceBefDi\",
        T1.\"DiscPrcnt\",
        T1.\"TaxCode\",
        T1.\"LineTotal\"
        From SB1CSL.INV1 T1 INNER JOIN SB1CSL.OINV T2 ON T1.\"DocEntry\" = T2.\"DocEntry\"
        where T2.\"DocNum\"='{$invoice}'");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function directionsUser($CardCode){
        $stmt = Connection::conectSap()->prepare("SELECT \"Address\", \"CardCode\",\"Street\",\"StreetNo\",\"Block\",\"ZipCode\",\"City\",\"Country\",\"State\",\"AdresType\" FROM SB1CSL.\"CRD1\" WHERE \"CardCode\" = '{$CardCode}'");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }



    static public function showClients($CardCode){
        $stmt = Connection::conect()->prepare("SELECT c.id, c.idsap, c.fullname, c.email, c.phone1, c.phone2, c.phone3, c.rfc, c.concatperson, c.status,
        s.name segment, s.id idsegment, sa.name saleperson, sa.id idsaleperson, g.name namegroup, g.id idgroup, p.name pharmacychain, p.id idpharmacychain
        FROM `clients` c
        INNER JOIN `segments` s ON s.id = c.idsegment
        INNER JOIN `salepersons` sa ON sa.id = c.idsaleperson 
        INNER JOIN `groups` g ON g.id = c.idgroup
        INNER JOIN `pharmacychains` P ON p.id = c.idpharmacychain WHERE c.idsap IN ({$CardCode})");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function showSalePerson($SalePerson){
        $stmt = Connection::conect()->prepare("SELECT * FROM salepersons WHERE idsap IN ({$SalePerson})");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }
}