<?php

require_once "connections/connection.php";

class  ModelReason{
    static public function activityreason(){
        $stmt = Connection::conect()->prepare("SELECT id value, name label FROM `activityreason`");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }
    static public function cancellationreason(){
        $stmt = Connection::conect()->prepare("SELECT id value, name label FROM `cancellationreason`");
        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }
    static public function incidentsreason(){
        $stmt = Connection::conect()->prepare("SELECT id value, name label FROM `incidentsreason`");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function statusreason(){
        $stmt = Connection::conect()->prepare("SELECT id value, name label FROM `statusactivity`");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }
}
