# ZOO REST API 
###
Casual basic ready to use REST API for zoo

## endpoints 
**/api/animals**  `[GET]` - get all animals, answer example
```json
{
  {
    "id": 1,
    "name": "genadiy",
    "type": "turtle",
    "energy": 70
  },
  {
    "id": 2,
    "name": "anton",
    "type": "lion",
    "energy": 27
  }
}
```
**/api/animals/{id}**  `[GET]` - get specific animal in zoo, answer example
```json
{
  "id": 1,
  "name": "genadiy",
  "type": "turtle",
  "energy": 70
}
```

**/api/animals**  `[POST]` - create new animal, energy choosing randomly in range 1 - 100 body json example
```json
{
  "name": "genadiy",
  "type": "turtle"
}
```
**/api/animals/{id}/feed**  `[PUT]` - feed specific animal, energy cant upgrade more than 100, and value of food cant be more than 100, body json example
```json
{
  20
}
```
**/api/animals/{id}**  `[DELETE]` - delete animal, just returning 204 if successufuly deleted
