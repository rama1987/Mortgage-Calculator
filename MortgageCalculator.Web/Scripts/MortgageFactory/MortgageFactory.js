angular.module('MortgageCalsApp')
    .factory('MortgageCalsFactory', ['$http', function ($http) {

        var mortgageCalsFactory = {};

        mortgageCalsFactory.GetMortgageList = function () {
            return $http.get('/Home/AllMortgages');
        };

        mortgageCalsFactory.GetMortgagetype = function () {
            return $http.get('/Home/GetMortgagetype');
        };

        mortgageCalsFactory.CalculateMortgage = function (MortgageModel) {
            return $http({
                url: "/Home/MortgageCals",
                dataType: 'json',
                method: 'POST',
                data: MortgageModel,
                headers: { "Content-Type": "application/json" }
            })
        };

        return mortgageCalsFactory;
    }]);