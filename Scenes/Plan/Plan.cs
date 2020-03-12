using Godot;
using System;
using System.Collections.Generic;

public class Plan : Node2D
{

	private Random rand;

	private TileMap _tileMap1;
	private TileMap _tileMap2;
	private TileMap _tileMap3;
	private TileMap _tileMap4;

	//Variables pour definir la taille de la Map 

	private int size = 25; //Nombre de bloques sur un coté de la Map  // PAS UTILISE CAR CREATMAP() NE FONCTIONNE PAS
	private int m_max = 5; //Nombre bocks montagnes à trois etages max
	private int m_min = 3; //Nombre bocks montagnes à trois etages min
	private int max_x = 31; //Coordonées max d'un bloque sur l'axe x
	private int min_x = -16; //Coordonnées min d'un bloque sur l'axe x
	private int max_y = 19; //Coordonées max d'un bloque sur l'axe y
	private int min_y = -29; //Cooronnées min d'un bloque en y

	// Variables modifiables pour définir le nombres d'éléments sur la Map

	private int max_flaque_eau = 4; //Nombre maximum de flaques d'eau
	private int min_flaque_eau = 2; //Nombre minimum de flaque d'eau
	private int max_block_flaque_eau = 10; //Nombre max de bloques eau pour une flaque
	private int min_block_flaque_eau = 5; //Nombre Minimum de bloques eau pour une flaque

	//Vairable permettant d'indiquer l'indexe des bloques

	private int index_terre = 0;
	private int index_boite = 3;
	private int index_eau = 2;
	private int indexe_montagne = 8;
	private int index_sable = 5;


	public override void _Ready()
	{


		rand = new Random();
		int nbr_flaque_eau = rand.Next(min_flaque_eau, max_flaque_eau + 1);
		_tileMap1 = (TileMap) GetNode("Navigation2D/TileMap1");
		_tileMap2 = (TileMap) GetNode("Navigation2D/TileMap2");
		_tileMap3 = (TileMap) GetNode("Navigation2D/TileMap3");
		_tileMap4 = (TileMap) GetNode("Navigation2D/TileMap4");


		//CreatMap2(10); //CREE MAP

		Montagne();
		/*
		List<(int, int)> coordonnes_base_flaques = new List<(int, int)>();
		for (int i = 0; i < nbr_flaque_eau; i++)
		{
			int rand_x = rand.Next(min_x, max_x + 1);
			int rand_y = rand.Next(min_y, max_y + 1);
			int indexe = _tileMap1.GetCell(rand_x, rand_y);
			if (indexe == 0)
			{
				coordonnes_base_flaques.Add((rand_x, rand_y));
				int nbr_block_eau = rand.Next(min_block_flaque_eau, max_block_flaque_eau + 1);
				_tileMap1.SetCell(rand_x, rand_y, index_eau);
				nbr_block_eau++;
				int j = 0;
				while (j < nbr_block_eau)
				{
					int deplacement = rand.Next(0, 4);

					switch (deplacement)
					{
						case 0:
							{
								rand_x++;
								if (_tileMap1.GetCell(rand_x, rand_y) == index_terre)
								{
									_tileMap1.SetCell(rand_x, rand_y, index_eau);
								}
								if (_tileMap1.GetCell(rand_x + 1, rand_y) == index_terre)
								{

									_tileMap1.SetCell(rand_x, rand_y, index_eau);
									j++;
									if (_tileMap1.GetCell(rand_x + 1, rand_y) == index_terre)
									{
										_tileMap1.SetCell(rand_x + 1, rand_y, index_eau);
										j++;
									}
									if (_tileMap1.GetCell(rand_x, rand_y + 1) == index_terre)
									{
										_tileMap1.SetCell(rand_x, rand_y + 1, index_eau);
										j++;
									}

									if (_tileMap1.GetCell(rand_x, rand_y - 1) == index_terre)
									{
										_tileMap1.SetCell(rand_x, rand_y - 1, index_eau);
										j++;
									}
								}
								break;
							}

						case 1:
							{
								rand_x--;
								if (_tileMap1.GetCell(rand_x, rand_y) == index_terre)
								{
									_tileMap1.SetCell(rand_x, rand_y, index_eau);
								}

								if (_tileMap1.GetCell(rand_x - 1, rand_y) == index_terre)
								{

									_tileMap1.SetCell(rand_x - 1, rand_y, index_eau);
									j++;
									if (_tileMap1.GetCell(rand_x - 1, rand_y) == index_terre)
									{
										_tileMap1.SetCell(rand_x - 1, rand_y, index_eau);
										j++;
									}
									if (_tileMap1.GetCell(rand_x, rand_y + 1) == index_terre)
									{
										_tileMap1.SetCell(rand_x, rand_y + 1, index_eau);
										j++;
									}
									if (_tileMap1.GetCell(rand_x, rand_y - 1) == index_terre)
									{
										_tileMap1.SetCell(rand_x, rand_y - 1, index_eau);
										j++;
									}
								}
								break;
							}

						case 2:
							{
								rand_y++;
								if (_tileMap1.GetCell(rand_x, rand_y) == index_terre)
								{
									_tileMap1.SetCell(rand_x, rand_y, index_eau);
								}

								if (_tileMap1.GetCell(rand_x, rand_y + 1) == index_terre)
								{
									_tileMap1.SetCell(rand_x, rand_y, index_eau);
									j++;
									if (_tileMap1.GetCell(rand_x + 1, rand_y) == index_terre)
									{
										_tileMap1.SetCell(rand_x + 1, rand_y, index_eau);
										j++;
									}
									if (_tileMap1.GetCell(rand_x - 1, rand_y) == index_terre)
									{
										_tileMap1.SetCell(rand_x - 1, rand_y, index_eau);
										j++;
									}
									if (_tileMap1.GetCell(rand_x, rand_y + 1) == index_terre)
									{
										_tileMap1.SetCell(rand_x, rand_y + 1, index_eau);
										j++;
									}
								}
								break;
							}
						case 3:
							{
								rand_y--;
								if (_tileMap1.GetCell(rand_x, rand_y) == index_terre)
								{
									_tileMap1.SetCell(rand_x, rand_y, index_eau);
								}

								if (_tileMap1.GetCell(rand_x, rand_y - 1) == index_terre)
								{
									_tileMap1.SetCell(rand_x, rand_y, index_eau);
									j++;
									if (_tileMap1.GetCell(rand_x + 1, rand_y) == index_terre)
									{
										_tileMap1.SetCell(rand_x + 1, rand_y, index_eau);
										j++;
									}
									if (_tileMap1.GetCell(rand_x - 1, rand_y) == index_terre)
									{
										_tileMap1.SetCell(rand_x - 1, rand_y, index_eau);
										j++;
									}
									if (_tileMap1.GetCell(rand_x, rand_y - 1) == index_terre)
									{
										_tileMap1.SetCell(rand_x, rand_y - 1, index_eau);
										j++;
									}
								}
								break;
							}
					}
				}
			}
			else
			{
				i--;
			}
		}
		//AJOUT SABLE SUR MAP   
		Sable(coordonnes_base_flaques);*/
	}

	// A FAIRE
	//ENLEVER LA CREATION DES LAC DE _READY ET CREER UNE FONCTION LE FAISANT AFIN DE CLARIFIER LE CODE !
	private void Lac()
	{
		
	}
	//FONCTION AJOUTANT SABLE
	private void Sable(List<(int, int)> list_coord)
	{
		foreach (var coord in list_coord)
		{
			(int x, int y) = coord;
			SableGauche(x, y);
			SableHaut(x, y);
			SableBas(x, y);
			SableDroite(x, y);
		}
	}
	

	private void SableDroite(int x, int y)
	{
		if (_tileMap1.GetCell(x, y) == index_terre || _tileMap1.GetCell(x, y) == index_sable)
		{
			_tileMap1.SetCell(x, y, index_sable);
		}
		else
		{
			if (_tileMap1.GetCell(x, y) == index_eau)
			{
				SableDroite(x + 1, y + 1);
				SableDroite(x + 1, y);
				SableDroite(x + 1, y - 1);
			}
		}
	}

	private void SableGauche(int x, int y)
	{
		if (_tileMap1.GetCell(x, y) == index_terre || _tileMap1.GetCell(x, y) == index_sable)
		{
			_tileMap1.SetCell(x, y, index_sable);
		}
		else
		{
			if (_tileMap1.GetCell(x, y) == index_eau)
			{
				SableGauche(x - 1, y + 1);
				SableGauche(x - 1, y);
				SableGauche(x - 1, y - 1);
			}
		}
	}

	private void SableHaut(int x, int y)
	{
		if (_tileMap1.GetCell(x, y) == index_terre || _tileMap1.GetCell(x, y) == index_sable)
		{
			_tileMap1.SetCell(x, y, index_sable);
		}

		if (_tileMap1.GetCell(x, y) == index_eau)
		{
			SableHaut(x + 1, y + 1);
			SableHaut(x, y + 1);
			SableHaut(x - 1, y + 1);
		}

	}

	private void SableBas(int x, int y)
	{
		if (_tileMap1.GetCell(x, y) == index_terre || _tileMap1.GetCell(x, y) == index_sable)
		{
			_tileMap1.SetCell(x, y, index_sable);
		}
		else
		{
			if (_tileMap1.GetCell(x, y) == index_eau)
			{
				SableBas(x + 1, y - 1);
				SableBas(x, y - 1);
				SableBas(x - 1, y - 1);
			}
		}
	}

	//FONCTION CREANT LA MONTAGNE
	private void Montagne()
	{
		int nbr_m = rand.Next(m_min, m_max);
		int rand_m_x = rand.Next(min_x, max_x + 1);
		int rand_m_y = rand.Next(min_y, max_y + 1);
		int indexe_m = _tileMap1.GetCell(rand_m_x, rand_m_y);
		if (indexe_m == index_terre)
		{
			_tileMap4.SetCell(rand_m_x, rand_m_y, indexe_montagne);
			_tileMap1.SetCell(rand_m_x, rand_m_y, indexe_montagne);
			Montagne_Lv2(rand_m_x + 1, rand_m_y + 1);
			int i = 1;
			while (i < nbr_m)
			{
				int alea = rand.Next(0, 4);
				switch (alea)
				{
					case 0:
						{
							if (_tileMap1.GetCell(rand_m_x - 2, rand_m_y - 2) == index_terre)
							{
								rand_m_x -= 2;
								rand_m_y -= 2;
								_tileMap1.SetCell(rand_m_x, rand_m_y, indexe_montagne);
								_tileMap4.SetCell(rand_m_x, rand_m_y, indexe_montagne);
								Montagne_Lv2(rand_m_x + 1, rand_m_y + 1);
								i++;
							}

							break;
						}

					case 1:
						{
							if (_tileMap1.GetCell(rand_m_x + 2, rand_m_y + 2) == index_terre)
							{
								rand_m_x += 2;
								rand_m_y += 2;
								_tileMap1.SetCell(rand_m_x, rand_m_y, indexe_montagne);
								_tileMap4.SetCell(rand_m_x, rand_m_y, indexe_montagne);
								Montagne_Lv2(rand_m_x + 1, rand_m_y + 1);
								i++;
							}

							break;
						}

					case 2:
						{
							if (_tileMap1.GetCell(rand_m_x - 2, rand_m_y + 2) == index_terre)
							{
								rand_m_x -= 2;
								rand_m_y += 2;
								_tileMap1.SetCell(rand_m_x, rand_m_y, indexe_montagne);
								_tileMap4.SetCell(rand_m_x, rand_m_y, indexe_montagne);
								Montagne_Lv2(rand_m_x + 1, rand_m_y + 1);
								i++;
							}

							break;
						}

					case 3:
						{

							if (_tileMap1.GetCell(rand_m_x + 2, rand_m_y - 2) == index_terre)
							{
								rand_m_x += 2;
								rand_m_y -= 2;
								_tileMap1.SetCell(rand_m_x, rand_m_y, indexe_montagne);
								_tileMap4.SetCell(rand_m_x, rand_m_y, indexe_montagne);
								Montagne_Lv2(rand_m_x + 1, rand_m_y + 1);
								i++;
							}

							break;
						}
				}
			}
		}
		else
		{
			Montagne();
		}
	}
	
	//FONCTION CREANT LA MONTAGNE AU NIVEAU2 (TileMap3)
	private void Montagne_Lv2(int x, int y)
	{
		if (_tileMap1.GetCell(x - 1, y - 1) == index_terre || _tileMap1.GetCell(x - 1, y - 1) == indexe_montagne)
		{
			_tileMap1.SetCell(x - 1, y - 1, indexe_montagne);
			_tileMap3.SetCell(x - 1, y - 1, indexe_montagne);
			Montagne_Lv3(x, y);
		}
		if (_tileMap1.GetCell(x + 1, y + 1) == index_terre || _tileMap1.GetCell(x + 1, y + 1) == indexe_montagne)
		{
			_tileMap3.SetCell(x + 1, y + 1, indexe_montagne);
			_tileMap1.SetCell(x + 1, y + 1, indexe_montagne);
			Montagne_Lv3(x + 2, y + 2);
		}
		if (_tileMap1.GetCell(x, y - 1) == index_terre || _tileMap1.GetCell(x, y - 1) == indexe_montagne)
		{
			_tileMap3.SetCell(x, y - 1, indexe_montagne);
			_tileMap1.SetCell(x, y - 1, indexe_montagne);
			Montagne_Lv3(x + 1, y);
		}
		if (_tileMap1.GetCell(x - 1, y) == index_terre || _tileMap1.GetCell(x - 1, y) == indexe_montagne)
		{
			_tileMap3.SetCell(x - 1, y, indexe_montagne);
			_tileMap1.SetCell(x - 1, y, indexe_montagne);
			Montagne_Lv3(x, y + 1);
		}
		if (_tileMap1.GetCell(x - 1, y + 1) == index_terre || _tileMap1.GetCell(x - 1, y + 1) == indexe_montagne)
		{
			_tileMap3.SetCell(x - 1, y + 1, indexe_montagne);
			_tileMap1.SetCell(x - 1, y + 1, indexe_montagne);
			Montagne_Lv3(x, y + 2);
		}
		if (_tileMap1.GetCell(x + 1, y - 1) == index_terre || _tileMap1.GetCell(x + 1, y - 1) == indexe_montagne)
		{
			_tileMap3.SetCell(x + 1, y - 1, indexe_montagne);
			_tileMap1.SetCell(x + 1, y - 1, indexe_montagne);
			Montagne_Lv3(x + 2, y);
		}
		if (_tileMap1.GetCell(x + 1, y) == index_terre || _tileMap1.GetCell(x + 1, y) == indexe_montagne)
		{
			_tileMap3.SetCell(x + 1, y, indexe_montagne);
			_tileMap1.SetCell(x + 1, y, indexe_montagne);
			Montagne_Lv3(x + 2, y + 1);
		}
		if (_tileMap1.GetCell(x, y + 1) == index_terre || _tileMap1.GetCell(x, y + 1) == indexe_montagne)
		{
			_tileMap3.SetCell(x, y + 1, indexe_montagne);
			_tileMap1.SetCell(x, y + 1, indexe_montagne);
			Montagne_Lv3(x + 1, y + 2);
		}
	}

	// FONCTION CREANT LA MONTAGNE AU NIVEAU DU SOL (TileMap2)
	private void Montagne_Lv3(int x, int y)
	{
		if (_tileMap1.GetCell(x - 1, y - 1) == index_terre)
		{
			_tileMap1.SetCell(x - 1, y - 1, indexe_montagne);
			_tileMap2.SetCell(x - 1, y - 1, indexe_montagne);
		}
		if (_tileMap1.GetCell(x + 1, y + 1) == index_terre)
		{
			_tileMap2.SetCell(x + 1, y + 1, indexe_montagne);
			_tileMap1.SetCell(x + 1, y + 1, indexe_montagne);

		}
		if (_tileMap1.GetCell(x, y - 1) == index_terre)
		{
			_tileMap2.SetCell(x, y - 1, indexe_montagne);
			_tileMap1.SetCell(x, y - 1, indexe_montagne);

		}
		if (_tileMap1.GetCell(x - 1, y) == index_terre)
		{
			_tileMap2.SetCell(x - 1, y, indexe_montagne);
			_tileMap1.SetCell(x - 1, y, indexe_montagne);

		}
		if (_tileMap1.GetCell(x - 1, y + 1) == index_terre)
		{
			_tileMap2.SetCell(x - 1, y + 1, indexe_montagne);
			_tileMap1.SetCell(x - 1, y + 1, indexe_montagne);

		}
		if (_tileMap1.GetCell(x + 1, y - 1) == index_terre)
		{
			_tileMap2.SetCell(x + 1, y - 1, indexe_montagne);
			_tileMap1.SetCell(x + 1, y - 1, indexe_montagne);

		}
		if (_tileMap1.GetCell(x + 1, y) == index_terre)
		{
			_tileMap2.SetCell(x + 1, y, indexe_montagne);
			_tileMap1.SetCell(x + 1, y, indexe_montagne);

		}

		if (_tileMap1.GetCell(x, y + 1) == index_terre)
		{
			_tileMap2.SetCell(x, y + 1, indexe_montagne);
			_tileMap1.SetCell(x, y + 1, indexe_montagne);
		}
	}

	//CREE MAP D'UNE TAILLE DONNEE
	// NE MARCHE PAS !!
	
	// A FAIRE (PB AVEC LES INDEXES DE SETCELL)
	public void CreatMap2(int size_ask)
	{
		int start_x = -16;
		int start_y = -5;



		for (int i = 0; i < size_ask; i++)
		{
			int x = start_x;
			int y = start_y;
			_tileMap1.SetCell(x + 1, y + 2, 4);
			for (int j = start_y; j > -size_ask + y + 1; j--)
			{
				_tileMap1.SetCell(x, j, 4);
				x++;
			}

			x = start_x;
			for (int j = start_y; j > -size_ask + y + 1; j--)
			{
				_tileMap1.SetCell(x - 1, j, 4);
				x++;
			}

			start_x++;
			start_y++;
			_tileMap1.SetCell(start_x, start_y, -1);
		}
	}

	//PERMET DE RECREER UNE MAP JUSTE EN CLIQUANT SUR ESPACE (POUR GAGNER DU TEMPS POUR TESTER, SERA SUPPRIME PAR LA SUITE)
	public override void _Process(float delta)
	{
		if (Input.IsKeyPressed((int)KeyList.Space))
		{
			GetTree().ReloadCurrentScene();
		}
	}
}
