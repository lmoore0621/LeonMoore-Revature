(function (na) {
    'use strict';

    na.service('contactSvc', ['$http', function ($http) {
        return function (id, pass, fail) {
            $http.headers
            $http.get('http://pokeapi.co/api/v2/pokemon/' + id).then(pass, fail)
        }
    }]);

    na.factory('contactFac', ['$http', function ($http) {
        return {
            get: function(id, pass, fail) {
                $http.get('http://pokeapi.co/api/v2/pokemon/' + id).then(pass, fail)
            }
        }
    }]);
})(window.ngapp);