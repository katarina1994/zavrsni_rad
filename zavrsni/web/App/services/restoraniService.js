web.factory('restoraniService', ['$http', function ($http) {

    var restoraniService = {};

    restoraniService.getRestorani = function () {
        return $http.get('api/Restorani');
    }

    restoraniService.getRestoraniByID = function (id) {
        return $http.get('api/Restorani/GetRestoraniByID/'+id);
    }

  
    return restoraniService;
}]);
