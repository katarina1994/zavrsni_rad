web.factory('jela1Service', ['$http', function ($http) {

var jela1Service = {}

jela1Service.getJelaByID = function (id) {
    return $http.get('api/Jela/GetJelaByID/' + id);
}

return jela1Service;
    
}]);