# Try Recipe API

- [Try Recipe API](#try-recipe-api)
  - [Try Recipe](#try-recipe)
    - [Try Recipe Request](#try-recipe-request)
    - [Try Recipe Response](#try-recipe-response)
  - [Get Recipe](#get-recipe)
    - [Get Recipe Request](#get-recipe-request)
    - [Get Recipe Response](#get-recipe-response)
  - [Update Recipe](#update-recipe)
    - [Update Recipe Request](#update-recipe-request)
    - [Update Recipe Response](#update-recipe-response)
  - [Delete Recipe](#delete-recipe)
    - [Delete Recipe Request](#delete-recipe-request)
    - [Delete Recipe Response](#delete-recipe-response)

## Try Recipe

### Try Recipe Request

```js
POST /recipes
```

```json
{
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy recipe..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

### Try Recipe Response

```js
201 Created
```

```yml
Location: {{host}}/Recipes/{{id}}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy recipe..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2022-04-06T12:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

## Get Recipe

### Get Recipe Request

```js
GET /recipes/{{id}}
```

### Get Recipe Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2022-04-06T12:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

## Update Recipe

### Update Recipe Request

```js
PUT /recipes/{{id}}
```

```json
{
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

### Update Recipe Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/Recipes/{{id}}
```

## Delete Recipe

### Delete Recipe Request

```js
DELETE /recipes/{{id}}
```

### Delete Recipe Response

```js
204 No Content
```