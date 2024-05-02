<?php

require_once "connections/connection.php";

class  ModelSyncClient{
    static public function showClients($ids){
        // var_dump($ids);
        // exit;
        $stmt = Connection::conectsap()->prepare("SELECT \"CardCode\" AS \"idsap\",
		\"CardName\" AS \"fullname\",
		\"CardType\" AS \"type\",
		\"GroupCode\" AS \"group\",
		\"LicTradNum\" AS \"rfc\",
		\"SlpCode\" AS \"saleperson\",
		CASE 
		WHEN \"QryGroup19\" = 'Y' THEN '2'
		WHEN \"QryGroup20\" = 'Y' THEN '3'
		WHEN \"QryGroup21\" = 'Y' THEN '4'
		WHEN \"QryGroup22\" = 'Y' THEN '5'
		WHEN \"QryGroup23\" = 'Y' THEN '6'
		ELSE '1'
		END AS \"segment\"
        FROM SB1CSL.OCRD 
        WHERE \"CardType\" = 'C' AND \"CardCode\" NOT IN ({$ids})");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function groups(){
        $stmt = Connection::conect()->prepare("SELECT `id`, `idsap` FROM `groups`");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        $stmt=null;
    }

    static public function saleperson(){
        $stmt = Connection::conect()->prepare("SELECT `id`, `idsap` FROM `salepersons`");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        $stmt=null;
    }

    static public function create($fields){
        $stmt = Connection::conect()->prepare("INSERT INTO `clients`(`idsap`,`fullname`,`rfc`, `idsegment`, `idgroup`, `idsaleperson`, `idpharmacychain`) 
                                                VALUES (:idsap,:fullname,:rfc,:idsegment,:idgroup,:idsaleperson,:idpharmacychain)");

        $stmt -> bindParam(":idsap", $fields['idsap'], PDO::PARAM_STR);
        $stmt -> bindParam(":fullname", $fields['fullname'], PDO::PARAM_STR);
        $stmt -> bindParam(":rfc", $fields['rfc'], PDO::PARAM_STR);
        $stmt -> bindParam(":idsegment", $fields['segment'], PDO::PARAM_STR);
        $stmt -> bindParam(":idgroup", $fields['idgroup'], PDO::PARAM_STR);
        $stmt -> bindParam(":idsaleperson", $fields['idsaleperson'], PDO::PARAM_STR);
        $stmt -> bindParam(":idpharmacychain", $fields['pharmacy'], PDO::PARAM_STR);


        if($stmt->execute()) return array("status"=>"success");
        else messageErrorCode(Connection::conect()->errorInfo(),200);

        $stmt=null;
    }
}