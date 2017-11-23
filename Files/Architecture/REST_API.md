# REST API

Bei jedem folgenden Request muss sich der Client indentifizieren (z.B. durch eine SessionID):

GET /AppStimmer -> lädt alle für den Client relevanten AppStimmer 
GET /AppStimmer?skip=n&take=m -> lädt m für dem Client relevante AppStimmer ausgehend von n.
GET /AppStimmer/ID -> lädt einen bestimmten AppStimmer
PUT /AppStimmer/ID/Vote/(-1|1) -> Client stimmt für einen AppStimmer ab. -1 für downvote und (+)1 für upvote
DELETE /AppStimmer/ID -> löscht einen AppStimmer (funktioniert nur wenn man der Ersteller ist)
POST /AppStimmer -> erstellt einen neuen AppStimmer. Gibt eine ID zurück. Benötigten Daten werden im Body mitgeschickt.