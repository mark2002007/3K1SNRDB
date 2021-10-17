using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neo4jClient;
using Neo4jClient.Cypher;

namespace _3K1SNRDB.Logic;

public class Neo4jCRUD
{
    private GraphClient client { get; set; }

    public Neo4jCRUD()
    {
        client = new GraphClient(new Uri("http://localhost:7474/db/data/"), "neo4j", "password");
        client.Connect();
    }

    public void AddUser(UserModel user) =>
        client.Cypher
            .Create("(user:User {newUser})")
            .WithParam("newUser", user)
            .ExecuteWithoutResults();

    public void AddUser(Guid id) =>
        AddUser(new UserModel() { id = id });

    public List<UserModel> GetAllUsers() =>
        (List<UserModel>)client.Cypher
            .Match("(u:User)")
            .Return(u => u.As<UserModel>())
            .Results;

    public void AddFriend(Guid userId, Guid friendId) =>
        client.Cypher
            .Match("(user:User {id: {userId}})", "(friend:User {id:{friendId}})")
            .WithParam("userId", userId)
            .WithParam("friendId", friendId)
            .Create("(user)-[:HAS_FRIEND]->(friend)")
            .ExecuteWithoutResults();

    public void RemoveFriend(Guid userId, Guid friendId) =>
        client.Cypher
            .Match("(user:User {id:{userId}})-[r:HAS_FRIEND]->(friend:User {id:{friendId}})")
            .WithParam("userId", userId)
            .WithParam("friendId", friendId)
            .Delete("r")
            .ExecuteWithoutResults();

    public int GetDistance(Guid userFromId, Guid userToId) => client.Cypher
            .Match("p=shortestPath((userFrom:User{id:{userFromId}})-[*]-(userTo:User{id:{userToId}}))")
            .WithParam("userFromId", userFromId)
            .WithParam("userToId", userToId)
            .Return(p => Return.As<int>("length(p)"))
            .Results.FirstOrDefault();
}