app.controller('SealedController', ['$scope', '$http', function ($scope, $http) {
	var getSealedPool = function () {
		$http.get("/api/sealed/getPool")
			.success(function (data, status, headers, config) {
				$scope.pool = data;
			})
			.error(function (data, status, headers, config) {

			});
	};

	var movePoolToDeck = function (card, $index) {
		$scope.deck.push(card);
		$scope.pool.Cards.splice($index, 1);
	}

	var moveDeckToPool = function (card, $index) {
		$scope.pool.Cards.push(card);
		$scope.deck.splice($index, 1);
	}

	getSealedPool();

	$scope.deck = [];
	$scope.movePoolToDeck = movePoolToDeck;
	$scope.moveDeckToPool = moveDeckToPool;
}]);