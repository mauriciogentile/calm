#What's Calm?

Calm is a .NET library developed in C# that allows you to build SharePoint queries (SPQuery) cleaner than if you do it by hand. Calm makes it easier for SharePoint developers to build queries in a more expressive-type-safe manner.

##Using Calm

By using this library you can convert the following string:
```xml
<Query>
   <Where>
      <Or>
         <Eq>
            <FieldRef Name="ContentType" />
            <Value Type="Text">My Content Type</Value>
         </Eq>
         <IsNotNull>
            <FieldRef Name="Description" />
         </IsNotNull>
      </Or>
   </Where>
   <GroupBy Collapse="TRUE">
      <FieldRef Ascending="FALSE" Name="Title" />
   </GroupBy>
   <OrderBy>
      <FieldRef Name="_Author" />
      <FieldRef Name="AuthoringDate" />
      <FieldRef Ascending="TRUE" Name="AssignedTo" />
   </OrderBy>
</Query>
```

into the following C# code:

```js
var query = new Query()
{
    Where = new Where(
        new Or(
            new Eq<string>(fieldName: "ContentType", value: "My Content Type", type: SPFieldType.Text),
            new IsNotNull(fieldName: "Description"))),

    GroupBy = new GroupBy(fieldName: "Title", collapsed: true),
    OrderBy = new OrderBy(fieldName: "_Author").ThenBy(fieldName: "AuthoringDate").ThenBy(fieldName: "AssignedTo")
};

var spQuery = new SPQuery();
spQuery.Query = query.ToString();
```

##Have fun!
