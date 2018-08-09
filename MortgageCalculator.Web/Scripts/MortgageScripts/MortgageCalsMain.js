
(function () {
    "use strict";

    var app = angular.module('MortgageCalsApp', ['ngRoute']);

    app.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
        when('/Home',
            {
                templateUrl: 'Home/MortgageCalsHome',
                controller: 'MortgageCalsHomeController'
            })
        .when('/MortgageCals',
            {
                templateUrl: 'Home/MortgageCals'
            })
        .otherwise(
        {
            redirectTo: '/Home'
        });
    }
    ]);


}())


