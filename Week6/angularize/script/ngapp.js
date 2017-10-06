(function (na) {
    'use strict';

    var hw = angular.module('HelloWorld', ['ngRoute']);

    hw.config(['$routeProvider', function (banana) {
        banana
            .when('/home', {
                controller: 'homeCtrl',
                templateUrl: 'home/template.html'
        })
        .when('/contact', {
            controller: 'contact',
            templateUrl: 'contact/template.html'
        })
        .otherwise({
            redirectToUrl: '/home'
        });
    }]);

})(window.ngApp || (window.ngApp = {}));