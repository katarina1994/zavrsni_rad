web.factory('adminService', ['$http', function ($http) {

    var adminService = {}
    adminService.getUsers = function () {
        return $http.get('api/Account/GetUsers/');
    }

    return adminService;

}]);