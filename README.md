# Maze_TestGame

Игра в стиле TopDown. 
Управление персонажем происходит при ЛКМ по области передвижения (NavMesh + Raycast). При ЛКМ на врага происходит выстрел со стороны Игрока.
Поведение врага: патрулирование по точкам при помощи NavMeshAgent. На врага навешан 2 collider для определения персонажа с тэгом "Player". При обнаружении персонажа враг начинает его преследовать и стрелять. 
Игроку необходимл выйти из зоны действия collider'а врага.
Для маскировки используются картонные коробки (CardBox) - при пересечении collider'a коробки Игроком вызывается Event, который сообщает Врагу, что он спрятался.
