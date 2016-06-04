web.factory('adminService', ['$http', function ($http) {

    
    var adminService = {}
    adminService.getUsers = function () {
        return $http.get('api/Account/GetUsers/');
    }

    adminService.deleteKorisnik = function (id) {
        return $http.get('Korisnici/Delete/' + id);
    }
    return adminService;

}]);