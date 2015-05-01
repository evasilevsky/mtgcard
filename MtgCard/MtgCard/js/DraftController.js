var app = angular.module("Magic", []);

app.controller('DraftController', function($scope) {
	$scope.test = "hi";
});

function DraftController() {
	this.test = "Hi!";
}

DraftController.prototype.greet = function () {
	alert(this.name);
};

DraftController.prototype.addContact = function () {
	this.contacts.push({ type: 'email', value: 'yourname@example.org' });
};

DraftController.prototype.removeContact = function (contactToRemove) {
	var index = this.contacts.indexOf(contactToRemove);
	this.contacts.splice(index, 1);
};

DraftController.prototype.clearContact = function (contact) {
	contact.type = 'phone';
	contact.value = '';
};
