var category = angular.module("AngularModuloCategoria", []);




//import '../node_modules/angular-ui-grid/ui-grid.min.css';

category.controller("ControladorCategoria", function ($scope, $http, $mdDialog) {


    var vm = this;


    /***************
    Variables
    ****************/
    vm.ListaCategorias = [];
    /***************
    Variables
    ****************/
    vm.gridOptions = { enableSorting: true};
    vm.gridOptions.columnDefs =
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
    vm.gridOptions.data = [];




    vm.TraerListaCategoria = function() {


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


    vm.ShowWait = false;
    vm.GuardarCategoria = function(ev) {


       
        if (typeof vm.model == "undefined") {


            vm.showAlert = function() {
                // Appending dialog to document.body to cover sidenav in docs app
                // Modal dialogs should fully cover application
                // to prevent interaction outside of dialog
                $mdDialog.show(
                    $mdDialog.alert()
                    .clickOutsideToClose(true)
                    .title('Datos no válidos')
                    .textContent('Debe cargar un nombre de categoria')
                    .ok('Ok')
                    .targetEvent(ev)
                );
            };

            vm.showAlert();

        } else {

            vm.ShowWait = true;
            $http({
                method: "POST",
                url: "Category/Category/CreateCategory",
                data: vm.model
            }).then(function mySuccess(response) {
                console.log(response);
                window.location.pathname = "Category/Category/ListCategory";
                vm.ShowWait = false;

            }, function myError(response) {
                vm.ShowWait = false;
            });

        }

      

    }

  



  

});



   





