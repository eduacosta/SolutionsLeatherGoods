var category = angular.module("AngularModuloCategory", []);




//import '../node_modules/angular-ui-grid/ui-grid.min.css';

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
            name: 'Id',
            field:
                'Id'
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
            $scope.gridOptions.data = $scope.ListaCategorias;


        }, function myError(response) {
            
        });

    }


  



    $scope.TraerListaCategoria();

});



   





