angular.module("MortgageCalsApp").controller("MortgageCalsHomeController", ['$scope', 'MortgageCalsFactory', function ($scope, MortgageCalsFactory) {

    MortgageCalsFactory.GetMortgageList().then(function (response) {
        $scope.allMortgages = response.data;
    }, function (error) {
        alert("Error : " + response.data.Message);
    });

}]);

angular.module("MortgageCalsApp").filter('jsonDate', ['$filter', function ($filter) {
    return function (input, format) {
        return (input)
               ? $filter('date')(parseInt(input.substr(6)), format)
               : '';
    };
}]);

