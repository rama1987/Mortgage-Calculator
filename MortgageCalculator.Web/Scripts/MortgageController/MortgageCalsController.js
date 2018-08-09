angular.module("MortgageCalsApp").controller("MortgageCalsController", ['$scope', 'MortgageCalsFactory', function ($scope, MortgageCalsFactory) {
    $scope.totalInterest = 0;
    $scope.totalRepayment = 0;
    $scope.Mortgagetype = {};
    MortgageCalsFactory.GetMortgagetype().then(function Success(response) {
        $scope.Mortgagetype = response.data;
    },
        function Error(response) {
            console.log(response);
            alert(response.data.Message);
        }
        )

    $scope.CalsMortgage = function () {
        var mortgageModel = {};
        mortgageModel.PrincipalAmount = $scope.PrincipalAmount;
        mortgageModel.LoanTerm = $scope.LoanTerm;
        mortgageModel.Rate = $scope.Rate;

        MortgageCalsFactory.CalculateMortgage(mortgageModel).then(function Success(response) {
            $scope.totalInterest = response.data.TotalInterest;
            $scope.totalRepayment = response.data.TotalRepayment;
        },
        function Error(response) {
            console.log(response);
            alert(response.data.Message);
        }
        )
    }
}]);