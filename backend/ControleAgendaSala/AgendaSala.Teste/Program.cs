using AgendaSala.Database.Connection;
using AgendaSala.Database.Repositories;
using AgendaSala.Domain.Entities;
using AgendaSala.Domain.Enum;

//using AgendaSala.Database.Connection;

//NhibernateConnection.CreateSession();

Room room = new Room();
RoomRepository roomRepository = new RoomRepository();

//room.Name = "Sala 1";
//roomRepository.Insert(room);



Role role = new Role();
RoleRepository roleRepository = new RoleRepository();

//role.Name = "Administração";
//role.AcessType = AcessType.admin;

//roleRepository.Insert(role);




User user = new User();
UserRepository userRepository = new UserRepository();


//user.UserName = "kaique Oliveira";
//user.Email = "kaique@gmail.com";
//user.Password = "123";
//user.Role = roleRepository.FindId(3);

//userRepository.Insert(user);



Event _event = new Event();
EventRepository eventRepository = new EventRepository();

//_event.EventDate = DateTime.Parse("2022-12-01");
//_event.StartTime = DateTime.Parse("12:00:00");
//_event.EndTime = DateTime.Parse("12:30:00");
//_event.Duration = DateTime.Parse("00:30:00");
//_event.Room = roomRepository.FindId(2);
//_event.User =  userRepository.FindId(4);

//eventRepository.Insert(_event);

Console.WriteLine(eventRepository.FindAll());