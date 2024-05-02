<?php

require_once "connections/connection.php";

class  ModelHistory{
    static public function show(){
        $stmt = Connection::conect()->prepare('SELECT T0.*,
		T1.name activity,
        T2.name cancelled,
        T3.name incidented,
        T4.name status,
        T5.idsap idclient,
        T5.fullname clients,
        CONCAT(T6.name," ",T6.lastname) employer,
        T6.username employeruser
        FROM `activity` T0 
        INNER JOIN activityreason T1 ON T1.id = T0.idactivity
        INNER JOIN cancellationreason T2 ON T2.id = T0.idcancelation
        INNER JOIN incidentsreason T3 ON T3.id = T0.idincident
        INNER JOIN statusactivity T4 ON T4.id = T0.idstatus
        INNER JOIN clients T5 ON T5.id = T0.idclient
        INNER JOIN employers T6 ON T6.id = T0.idemployer');

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }
}
