(function (na) {
    'use strict';

    na.controller('homeCtrl', ['$scope', function($scope) {
        $scope.contact = {};
        $scope.formSubmit = function() {
            $scope.message = 'home sweet home';
            
        };
    }]);
})(window.ngapp);