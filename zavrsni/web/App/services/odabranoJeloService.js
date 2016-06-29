web.factory('odabranoJeloService', ['$http', function ($http) {

    var odabranoJeloService = {}

    odabranoJeloService.getOdabranaJela = function () {
        return $http.get('api/OdabranoJeloVoditelj');
    }

    odabranoJeloService.getOdabranaJelaID = function (id) {
        return $http.get('api/OdabranoJeloVoditelj/GetOdabranaJelaID/'+ id);
    }

    odabranoJeloService.odaberiJelo = function (id, odab_jelo, restid, mail, moja_adresa, vrijeme, ukupna) {
        return $http.get('/OdabranoJelo/Create/?newID=' + id + '&newKolicina=' + odab_jelo[1] + '&newMail=' + mail + '&newAdresa=' + moja_adresa + '&newVrijeme=' + vrijeme + '&newJeloID=' + odab_jelo[0] + '&newRestoranID=' + restid + '&newUkupnaCijena=' + ukupna);
    }

    odabranoJeloService.potvrdi = function (id) {
        return $http.get('api/Potvrda/Potvrda/' + id);
    }

    return odabranoJeloService;

}]);