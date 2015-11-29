(function () {

    angular
        .module('ZenchiDemo')
        .factory('projectService', projectService);


    projectService.$inject = ['$http', 'configService'];

    function projectService($http, configService) {
        return {
            getList: getList,
            add: add,
            update: update,
            remove: remove,
            get: get
        };


        function getList() {
            return $http.get(configService.zenchiApiProjectUrl())
                .then(getAllComplete);

            function getAllComplete(response) {

                var projects = response.data;

                return projects;
            }
        }

        function add(project) {

        }

        function update(project) {

        }

        function remove(projectId) {

        }

        function get(projectId) {

        }


    };

})();