web.factory('jela1Service', ['$http', function ($http) {

var jela1Service = {}

jela1Service.getJelaByID = function (id) {
    return $http.get('api/Jela/GetJelaByID/' + id);
}

jela1Service.getJelaTheirID = function (id) {
    return $http.get('api/Jela/GetJelaTheirID/' + id);
}

jela1Service.deleteJelo = function (id) {
    return $http.get('api/Jela/DeleteJelo/' + id);
}

jela1Service.insertJelo = function (id, naziv, cijena, detalji, tipid, restid) {
    return $http.get('/SaveJelo/Create/?newID=' + id + '&newNaziv_jelo=' + naziv + '&newCijena=' + cijena + '&newKratki_opis=' + detalji + '&newTipJelaID=' + tipid + '&newRestoranID=' + restid);
}

return jela1Service;
    
}]);