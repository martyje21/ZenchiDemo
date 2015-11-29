(function () {

    angular
        .module('ZenchiDemo')
        .controller('projectController', projectController);

    projectController.$inject = ['projectService'];


    function projectController(projectService) {
        var vm = this;
        vm.projects = [];

        activate();

        function activate() {
            return getProjects().then(function () {
                //log info
            });
        }


        function getProjects() {
            return projectService.getList()
                .then(function (data) {
                    vm.projects = data;
                    return vm.projects;
                });
        }

    }

})();