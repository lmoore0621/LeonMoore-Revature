(function (na) {
    'use strict';

    na.controller('homeCtrl', ['$scope', function($scope) {
        $scope.contact = {};
        $scope.formSubmit = function() {
            $scope.message = $scope.contact.name + 'has sent a message';
            setTimeout(function () {
                $scope.message = '';
            }, 5000);
        }

        $scope.papiSubmit = function () {
            function success(params) {
                
            }
        }
    }]);
})(window.ngapp);