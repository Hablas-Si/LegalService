# LegalService

LegalService er en mikrotjeneste, der håndterer juridiske forespørgsler i forbindelse med auktioner og brugere for Auktionshuset. Tjenesten interagerer med AuctionService og UserService via HTTP-klient og bruger HashiCorp Vault til autentifikation på endepunkter.

## Funktioner

- Henter liste over auktioner og detaljer om specifikke auktioner fra AuctionService.
- Henter detaljer om specifikke brugere fra UserService.
- Understøtter brugerlogin og JWT-token generering.
- Anvender HashiCorp Vault til sikker autentifikation og autorisation.
- Implementerer OpenAPI-kontrakt for interoperabilitet med myndigheder.

## HashiCorp Vault
LegalService bruger HashiCorp Vault til at sikre endpoints. Sørg for, at Vault er korrekt installeret og konfigureret. Du skal have en token og en opsat politik, der tillader adgang til nødvendige hemmeligheder.

# LegalService API Endpoints

## Auction Endpoints

### GET /api/legal/auctions

Henter en liste over auktioner.

**Sikkerhed:** Kræver Admin JWT-token.

### GET /api/legal/auctions/{auctionId}

Henter detaljer om en specifik auktion.

**Parametre:**
- `auctionId`: UUID for den auktion, der skal hentes. Tjek Database.

**Sikkerhed:** Kræver Admin JWT-token.

## User Endpoints

### GET /api/legal/users/{userId}

Henter detaljer om en specifik bruger.

**Parametre:**
- `userId`: UUID for den bruger, der skal hentes. Tjek Database.

**Sikkerhed:** Kræver Admin JWT-token.

## Auth Endpoints

### POST /api/legal/login

Brugerlogin og JWT-token generering.

**Body-indhold:**
```json
{
  "username": "JohnDoe",
  "password": "secret123"
}
