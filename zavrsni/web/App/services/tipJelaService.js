web.factory('tipJelaService', ['$http', function ($http) {

    var tipJelaService = {}

    tipJelaService.getTipJelaByID = function (id) {
        return $http.get('api/TipJela/GetTipJelaByID/' + id);
    }

    return tipJelaService;

}]);