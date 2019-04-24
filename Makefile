.PHONY: setup
setup:
	docker-compose build

.PHONY: build
build:
	docker-compose run customer-information-api dotnet build

.PHONY: serve
serve:
	docker-compose up customer-information-api

.PHONY: shell
shell:
	docker-compose run customer-information-api bash

.PHONY: test
test:
	docker-compose build customer-information-api-test && docker-compose up customer-information-api-test
