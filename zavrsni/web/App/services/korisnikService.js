web.factory('korisnikService', ['$http', function ($http) {

    var korisnikService = {}
    korisnikService.detalji = function (id) {
        return $http.get('/Korisnik/Details/');
    }

    korisnikService.edit = function (id) {
        return $http.get('/Korisnik/Details/?id=' + id);
    }

    return korisnikService;

}]);