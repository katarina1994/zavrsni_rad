web.factory('korisnikService', ['$http', function ($http) {

    var korisnikService = {}
    korisnikService.detalji = function (id) {
        return $http.get('/Korisnik/Details/');
    }

    korisnikService.edit = function (usern, isa, id, ime, prez, majl, oid, rid) {
        return $http.get('/Korisnik/Edit/?username=' + usern + '&id=' + id + '&ime=' + ime + '&prez=' + prez + '&majl=' + majl + '&oid=' + oid + '&rid=' + rid);
    }

    return korisnikService;

}]);