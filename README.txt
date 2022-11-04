Hoi Frank,

Bij deze mijn cloud database assignment.

hier de link naar mijn src: https://github.com/rubeninjehoofd/CloudDatabasesAssignment 

voordat je het kan runnen moet je een paar dingen doen.
Namelijk user secrets toevoegen.

Om dat te doen moet je rechtermuisknop op het project doen, en dan klikken op "Manage User Secrets". Als het goed is wordt er 
dan een bestand geopend. Zo niet, dan wordt de package waarschijnlijk geinstalleerd. Klik daarna weer op "Manage User Secrets".

voeg vervolgens deze regels toe aan het geopende bestand.
{
  "CosmosAccountKey": "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
  "SendGrindApiKey": "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",
  "MailSender": "650580@student.inholland.nl"
}

LET OP: CosmosAccountKey moet je zeer waarschijnlijk veranderen naar je eigen account key van jou cosmos emulator
Hetzelfde geldt voor MailSender, daar kan je een ander BESTAAND email adres van maken.

SendGridApiKey moet hetzelfde blijven.

Tip: de verzonden mail kan in de spambox terecht komen, dus let daar op ;)

Als iets niet werkt, dan hoor ik het graag!

Groetjes,

Ruben Schild, 650580