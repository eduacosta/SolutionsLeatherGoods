var category = angular.module("AngularModuloCategory", []);

import '../node_modules/angular-ui-grid/ui-grid.min.css';

category.controller("ctrControladorCategory", function ($scope, $http) {

    /***************
    Variables
    ****************/
    $scope.ListaCategorias = [];
    /***************
    Variables
    ****************/
    $scope.gridOptions = { enableSorting: true};
    $scope.gridOptions.columnDefs =
    [
        {
            name: 'ID',
            field:
                'ID'
        },
        {
            name: 'Name',
            field:
                'Name'
        },
    ];
    $scope.gridOptions.data = [];




    $scope.TraerListaCategoria = function() {


        $http({
            method: "GET",
            url: "Category/AllData"
        }).then(function mySuccess(response) {
            console.log(response.data);

            $scope.ListaCategorias = response.data;

   

        }, function myError(response) {
            
        });

    }


  



    $scope.TraerListaCategoria();

});



   





