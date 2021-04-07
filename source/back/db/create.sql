/*==============================================================*/
/* Table: Card                                                  */
/*==============================================================*/
create table Card (
   uidCard              nvarchar(40)         not null,
   uidCardList          nvarchar(40)         not null,
   tip                  nvarchar(1000)       not null,
   textBack             nvarchar(500)        not null,
   textFront            nvarchar(500)        not null,
   constraint pkCard primary key nonclustered (uidCard)
)
go

/*==============================================================*/
/* Table: CardList                                              */
/*==============================================================*/
create table CardList (
   uidCardList          nvarchar(40)         not null,
   uidUserOwner         nvarchar(40)         not null,
   idScope              smallint             not null,
   name                 nvarchar(100)        not null,
   constraint pkCardList primary key (uidCardList)
)
go

/*==============================================================*/
/* Index: fkCardList_Scope                                      */
/*==============================================================*/
create index fkCardList_Scope on CardList (
idScope ASC
)
go

/*==============================================================*/
/* Index: fkCardList_UserOwner                                  */
/*==============================================================*/
create index fkCardList_UserOwner on CardList (
uidUserOwner ASC
)
go

/*==============================================================*/
/* Table: Scope                                                 */
/*==============================================================*/
create table Scope (
   idScope              smallint             not null,
   name                 nvarchar(20)         not null,
   constraint pkScope primary key nonclustered (idScope)
)
go

/*==============================================================*/
/* Table: SignedCardList                                        */
/*==============================================================*/
create table SignedCardList (
   uidCardList          nvarchar(40)         not null,
   uidUser              nvarchar(40)         not null
)
go

/*==============================================================*/
/* Index: ukSignedCardList                                      */
/*==============================================================*/
create unique index ukSignedCardList on SignedCardList (
uidCardList ASC,
uidUser ASC
)
go

/*==============================================================*/
/* Table: "User"                                                */
/*==============================================================*/
create table "User" (
   uidUser              nvarchar(40)         not null,
   name                 nvarchar(100)        not null,
   login                nvarchar(100)        not null,
   constraint pkUser primary key nonclustered (uidUser)
)
go

alter table Card
   add constraint fkCard_CardList foreign key (uidCardList)
      references CardList (uidCardList)
go

alter table CardList
   add constraint fkCardList_Scope foreign key (idScope)
      references Scope (idScope)
go

alter table CardList
   add constraint fkCardList_UserOwner foreign key (uidUserOwner)
      references "User" (uidUser)
go

alter table SignedCardList
   add constraint fkSignedCardList_CardList foreign key (uidCardList)
      references CardList (uidCardList)
go

alter table SignedCardList
   add constraint fkSignedCardList_User foreign key (uidUser)
      references "User" (uidUser)
go
