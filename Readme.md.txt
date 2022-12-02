Modules:
Custom Terrain: It helps generate random shapes of terrain and most helpful in distributing the trees
If adding vegetation does not work, follow these steps:
1. Uncomment AddTag file
2. In CustomTerrain.cs comment the contents of Awake()
3. Remove and add the CustomTerrain
4. Comment AddTag file and contents of CustomTerrain.cs Awake()


When creating a new scene:
Create Terrain, shift the position so that center is at 0.
Generatae lighting
Change Environment in lighting to have fog
Generate Bake Navigation

