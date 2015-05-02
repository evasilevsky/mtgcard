var app = angular.module('MagicApp', []);

app.controller('DraftController', ['$scope', '$http', function ($scope, $http) {
	var getNextPack = function () {
		$http.get('/api/draft/getRandomPack')
			.success(function (data, status, headers, config) {
				$scope.currentPack = data.Cards;
			})
			.error(function (data, status, headers, config) {

			});
	};

	var addCard = function (card, $index) {
		$scope.draftedCards.push(card);
		$scope.currentPack.splice($index, 1);
	};
	$scope.addCard = addCard;

	$scope.draftedCards = [];
	$scope.currentPack = getNextPack();
	$scope.getNextPack = getNextPack;

	
}]);