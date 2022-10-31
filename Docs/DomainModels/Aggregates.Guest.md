# Domain Aggregates

## Guest

```csharp
class Guest
{
    // TODO: Add methods
}
```

```json
{
    "id": { "value": "00000000-0000-0000-0000-000000000000" },
    "firstName": "John",
    "lastName": "Doe",
    "profileImage": "https://www.gravatar.com/avatar/00000000000000000000000000000000?d=mp",
    "averageRating": 4.5,
    "userId": { "value": "00000000-0000-0000-0000-000000000000" },
    "upcomingDinnerIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],
    "pastDinnerIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],
    "pendingDinnerIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],
    "billIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],
    "menuReviewIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],
    "ratings": [
        {
            "id": { "value": "00000000-0000-0000-0000-000000000000" },
            "hostId": { "value": "00000000-0000-0000-0000-000000000000" },
            "dinnerId": { "value": "00000000-0000-0000-0000-000000000000" },
            "rating": 4,
            "createdDateTime": "2020-01-01T00:00:00.0000000Z",
            "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
        }
    ],
    "createdDateTime": "2020-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}
```
