var GAutoCompleteApp = angular.module('GAutoCompleteApp', ['angucomplete-alt']);
GAutoCompleteApp.controller('ngAutoCompleteController', ['$scope', '$http', '$filter', function ($scope, $http, $filter) {
    
    $scope.Products = null;
    $scope.SelectedProduct = null;

    //Populate data from database 
    $http({
        method: 'GET',
        url: '/Products/GetInitialProductsList'
    }).then(function (data) {
        $scope.Products = data.data;
    }, function () {
        alert('Error occured here from first');
    })
    
    //After select country event
    $scope.afterSelectedProduct = function (selected) {
        if (selected) {
            $scope.SelectedProduct = selected.originalObject;
        }
    }

    $scope.inputChanged = function (selectedText) {

        $http({
            method: 'GET',
            url: '/Products/SearchProductsList',
            params: { filterText: selectedText }
        }).then(function (data) {
            $scope.Products = data.data;
        }, function (error, status) {
            alert('Error occured here');
        });

    }
    
}]);