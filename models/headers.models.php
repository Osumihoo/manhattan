<?php 

class HeadersModel{
    static public function getHeaders($token){
        $query = "SELECT T1.id, T2.*
                  FROM authorizations T1 
                  INNER JOIN companies T2 ON T2.id = T1.idcompanie";
        $stmt = Connection::conect()->prepare($query);

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }
}