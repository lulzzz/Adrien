﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Humanizer;

namespace Adrien.Notation
{
	public partial class Tensor
	{		
		public static Tensor TwoD(string name, (int dim1, int dim2) dim) =>
			new Tensor(name, dim.dim1, dim.dim2);

		public static Tensor TwoD(string name, (int dim1, int dim2) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2);
			return Tensor.TwoD(name, dim);
		}

		public static Tensor TwoD(string name, (int dim1, int dim2) dim, string indexNameBase,
			out Index index1, out Index index2)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			return t;
		}
			
		public static Tensor ThreeD(string name, (int dim1, int dim2, int dim3) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3);

		public static Tensor ThreeD(string name, (int dim1, int dim2, int dim3) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3);
			return Tensor.ThreeD(name, dim);
		}

		public static Tensor ThreeD(string name, (int dim1, int dim2, int dim3) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			return t;
		}
			
		public static Tensor FourD(string name, (int dim1, int dim2, int dim3, int dim4) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4);

		public static Tensor FourD(string name, (int dim1, int dim2, int dim3, int dim4) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4);
			return Tensor.FourD(name, dim);
		}

		public static Tensor FourD(string name, (int dim1, int dim2, int dim3, int dim4) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			return t;
		}
			
		public static Tensor FiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5);

		public static Tensor FiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5);
			return Tensor.FiveD(name, dim);
		}

		public static Tensor FiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			return t;
		}
			
		public static Tensor SixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6);

		public static Tensor SixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6);
			return Tensor.SixD(name, dim);
		}

		public static Tensor SixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			return t;
		}
			
		public static Tensor SevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7);

		public static Tensor SevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7);
			return Tensor.SevenD(name, dim);
		}

		public static Tensor SevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			return t;
		}
			
		public static Tensor EightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8);

		public static Tensor EightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8);
			return Tensor.EightD(name, dim);
		}

		public static Tensor EightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			return t;
		}
			
		public static Tensor NineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9);

		public static Tensor NineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9);
			return Tensor.NineD(name, dim);
		}

		public static Tensor NineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			return t;
		}
			
		public static Tensor TenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10);

		public static Tensor TenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10);
			return Tensor.TenD(name, dim);
		}

		public static Tensor TenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			return t;
		}
			
		public static Tensor ElevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11);

		public static Tensor ElevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11);
			return Tensor.ElevenD(name, dim);
		}

		public static Tensor ElevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			return t;
		}
			
		public static Tensor TwelveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12);

		public static Tensor TwelveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12);
			return Tensor.TwelveD(name, dim);
		}

		public static Tensor TwelveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			return t;
		}
			
		public static Tensor ThirteenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13);

		public static Tensor ThirteenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13);
			return Tensor.ThirteenD(name, dim);
		}

		public static Tensor ThirteenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			return t;
		}
			
		public static Tensor FourteenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14);

		public static Tensor FourteenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14);
			return Tensor.FourteenD(name, dim);
		}

		public static Tensor FourteenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			return t;
		}
			
		public static Tensor FifteenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15);

		public static Tensor FifteenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15);
			return Tensor.FifteenD(name, dim);
		}

		public static Tensor FifteenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			return t;
		}
			
		public static Tensor SixteenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16);

		public static Tensor SixteenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16);
			return Tensor.SixteenD(name, dim);
		}

		public static Tensor SixteenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			return t;
		}
			
		public static Tensor SeventeenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17);

		public static Tensor SeventeenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17);
			return Tensor.SeventeenD(name, dim);
		}

		public static Tensor SeventeenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			return t;
		}
			
		public static Tensor EighteenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18);

		public static Tensor EighteenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18);
			return Tensor.EighteenD(name, dim);
		}

		public static Tensor EighteenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			return t;
		}
			
		public static Tensor NineteenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19);

		public static Tensor NineteenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19);
			return Tensor.NineteenD(name, dim);
		}

		public static Tensor NineteenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			return t;
		}
			
		public static Tensor TwentyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20);

		public static Tensor TwentyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20);
			return Tensor.TwentyD(name, dim);
		}

		public static Tensor TwentyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			return t;
		}
			
		public static Tensor TwentyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21);

		public static Tensor TwentyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21);
			return Tensor.TwentyOneD(name, dim);
		}

		public static Tensor TwentyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			return t;
		}
			
		public static Tensor TwentyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22);

		public static Tensor TwentyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22);
			return Tensor.TwentyTwoD(name, dim);
		}

		public static Tensor TwentyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			return t;
		}
			
		public static Tensor TwentyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23);

		public static Tensor TwentyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23);
			return Tensor.TwentyThreeD(name, dim);
		}

		public static Tensor TwentyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			return t;
		}
			
		public static Tensor TwentyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24);

		public static Tensor TwentyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24);
			return Tensor.TwentyFourD(name, dim);
		}

		public static Tensor TwentyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			return t;
		}
			
		public static Tensor TwentyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25);

		public static Tensor TwentyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25);
			return Tensor.TwentyFiveD(name, dim);
		}

		public static Tensor TwentyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			return t;
		}
			
		public static Tensor TwentySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26);

		public static Tensor TwentySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26);
			return Tensor.TwentySixD(name, dim);
		}

		public static Tensor TwentySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			return t;
		}
			
		public static Tensor TwentySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27);

		public static Tensor TwentySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27);
			return Tensor.TwentySevenD(name, dim);
		}

		public static Tensor TwentySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			return t;
		}
			
		public static Tensor TwentyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28);

		public static Tensor TwentyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28);
			return Tensor.TwentyEightD(name, dim);
		}

		public static Tensor TwentyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			return t;
		}
			
		public static Tensor TwentyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29);

		public static Tensor TwentyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29);
			return Tensor.TwentyNineD(name, dim);
		}

		public static Tensor TwentyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			return t;
		}
			
		public static Tensor ThirtyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30);

		public static Tensor ThirtyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30);
			return Tensor.ThirtyD(name, dim);
		}

		public static Tensor ThirtyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			return t;
		}
			
		public static Tensor ThirtyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31);

		public static Tensor ThirtyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31);
			return Tensor.ThirtyOneD(name, dim);
		}

		public static Tensor ThirtyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			return t;
		}
			
		public static Tensor ThirtyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32);

		public static Tensor ThirtyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32);
			return Tensor.ThirtyTwoD(name, dim);
		}

		public static Tensor ThirtyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			return t;
		}
			
		public static Tensor ThirtyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33);

		public static Tensor ThirtyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33);
			return Tensor.ThirtyThreeD(name, dim);
		}

		public static Tensor ThirtyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			return t;
		}
			
		public static Tensor ThirtyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34);

		public static Tensor ThirtyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34);
			return Tensor.ThirtyFourD(name, dim);
		}

		public static Tensor ThirtyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			return t;
		}
			
		public static Tensor ThirtyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35);

		public static Tensor ThirtyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35);
			return Tensor.ThirtyFiveD(name, dim);
		}

		public static Tensor ThirtyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			return t;
		}
			
		public static Tensor ThirtySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36);

		public static Tensor ThirtySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36);
			return Tensor.ThirtySixD(name, dim);
		}

		public static Tensor ThirtySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			return t;
		}
			
		public static Tensor ThirtySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37);

		public static Tensor ThirtySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37);
			return Tensor.ThirtySevenD(name, dim);
		}

		public static Tensor ThirtySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			return t;
		}
			
		public static Tensor ThirtyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38);

		public static Tensor ThirtyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38);
			return Tensor.ThirtyEightD(name, dim);
		}

		public static Tensor ThirtyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			return t;
		}
			
		public static Tensor ThirtyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39);

		public static Tensor ThirtyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39);
			return Tensor.ThirtyNineD(name, dim);
		}

		public static Tensor ThirtyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			return t;
		}
			
		public static Tensor FortyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40);

		public static Tensor FortyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40);
			return Tensor.FortyD(name, dim);
		}

		public static Tensor FortyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			return t;
		}
			
		public static Tensor FortyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41);

		public static Tensor FortyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41);
			return Tensor.FortyOneD(name, dim);
		}

		public static Tensor FortyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			return t;
		}
			
		public static Tensor FortyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42);

		public static Tensor FortyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42);
			return Tensor.FortyTwoD(name, dim);
		}

		public static Tensor FortyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			return t;
		}
			
		public static Tensor FortyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43);

		public static Tensor FortyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43);
			return Tensor.FortyThreeD(name, dim);
		}

		public static Tensor FortyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			return t;
		}
			
		public static Tensor FortyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44);

		public static Tensor FortyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44);
			return Tensor.FortyFourD(name, dim);
		}

		public static Tensor FortyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			return t;
		}
			
		public static Tensor FortyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45);

		public static Tensor FortyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45);
			return Tensor.FortyFiveD(name, dim);
		}

		public static Tensor FortyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			return t;
		}
			
		public static Tensor FortySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46);

		public static Tensor FortySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46);
			return Tensor.FortySixD(name, dim);
		}

		public static Tensor FortySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			return t;
		}
			
		public static Tensor FortySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47);

		public static Tensor FortySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47);
			return Tensor.FortySevenD(name, dim);
		}

		public static Tensor FortySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			return t;
		}
			
		public static Tensor FortyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48);

		public static Tensor FortyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48);
			return Tensor.FortyEightD(name, dim);
		}

		public static Tensor FortyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			return t;
		}
			
		public static Tensor FortyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49);

		public static Tensor FortyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49);
			return Tensor.FortyNineD(name, dim);
		}

		public static Tensor FortyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			return t;
		}
			
		public static Tensor FiftyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50);

		public static Tensor FiftyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50);
			return Tensor.FiftyD(name, dim);
		}

		public static Tensor FiftyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			return t;
		}
			
		public static Tensor FiftyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51);

		public static Tensor FiftyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51);
			return Tensor.FiftyOneD(name, dim);
		}

		public static Tensor FiftyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			return t;
		}
			
		public static Tensor FiftyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52);

		public static Tensor FiftyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52);
			return Tensor.FiftyTwoD(name, dim);
		}

		public static Tensor FiftyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			return t;
		}
			
		public static Tensor FiftyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53);

		public static Tensor FiftyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53);
			return Tensor.FiftyThreeD(name, dim);
		}

		public static Tensor FiftyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			return t;
		}
			
		public static Tensor FiftyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54);

		public static Tensor FiftyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54);
			return Tensor.FiftyFourD(name, dim);
		}

		public static Tensor FiftyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			return t;
		}
			
		public static Tensor FiftyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55);

		public static Tensor FiftyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55);
			return Tensor.FiftyFiveD(name, dim);
		}

		public static Tensor FiftyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			return t;
		}
			
		public static Tensor FiftySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56);

		public static Tensor FiftySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56);
			return Tensor.FiftySixD(name, dim);
		}

		public static Tensor FiftySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			return t;
		}
			
		public static Tensor FiftySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57);

		public static Tensor FiftySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57);
			return Tensor.FiftySevenD(name, dim);
		}

		public static Tensor FiftySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			return t;
		}
			
		public static Tensor FiftyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58);

		public static Tensor FiftyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58);
			return Tensor.FiftyEightD(name, dim);
		}

		public static Tensor FiftyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			return t;
		}
			
		public static Tensor FiftyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59);

		public static Tensor FiftyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59);
			return Tensor.FiftyNineD(name, dim);
		}

		public static Tensor FiftyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			return t;
		}
			
		public static Tensor SixtyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60);

		public static Tensor SixtyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60);
			return Tensor.SixtyD(name, dim);
		}

		public static Tensor SixtyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			return t;
		}
			
		public static Tensor SixtyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61);

		public static Tensor SixtyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61);
			return Tensor.SixtyOneD(name, dim);
		}

		public static Tensor SixtyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			return t;
		}
			
		public static Tensor SixtyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62);

		public static Tensor SixtyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62);
			return Tensor.SixtyTwoD(name, dim);
		}

		public static Tensor SixtyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			return t;
		}
			
		public static Tensor SixtyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63);

		public static Tensor SixtyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63);
			return Tensor.SixtyThreeD(name, dim);
		}

		public static Tensor SixtyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			return t;
		}
			
		public static Tensor SixtyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64);

		public static Tensor SixtyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64);
			return Tensor.SixtyFourD(name, dim);
		}

		public static Tensor SixtyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			return t;
		}
			
		public static Tensor SixtyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65);

		public static Tensor SixtyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65);
			return Tensor.SixtyFiveD(name, dim);
		}

		public static Tensor SixtyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			return t;
		}
			
		public static Tensor SixtySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66);

		public static Tensor SixtySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66);
			return Tensor.SixtySixD(name, dim);
		}

		public static Tensor SixtySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			return t;
		}
			
		public static Tensor SixtySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67);

		public static Tensor SixtySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67);
			return Tensor.SixtySevenD(name, dim);
		}

		public static Tensor SixtySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			return t;
		}
			
		public static Tensor SixtyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68);

		public static Tensor SixtyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68);
			return Tensor.SixtyEightD(name, dim);
		}

		public static Tensor SixtyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			return t;
		}
			
		public static Tensor SixtyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69);

		public static Tensor SixtyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69);
			return Tensor.SixtyNineD(name, dim);
		}

		public static Tensor SixtyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			return t;
		}
			
		public static Tensor SeventyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70);

		public static Tensor SeventyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70);
			return Tensor.SeventyD(name, dim);
		}

		public static Tensor SeventyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			return t;
		}
			
		public static Tensor SeventyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71);

		public static Tensor SeventyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71);
			return Tensor.SeventyOneD(name, dim);
		}

		public static Tensor SeventyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			return t;
		}
			
		public static Tensor SeventyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72);

		public static Tensor SeventyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72);
			return Tensor.SeventyTwoD(name, dim);
		}

		public static Tensor SeventyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			return t;
		}
			
		public static Tensor SeventyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73);

		public static Tensor SeventyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73);
			return Tensor.SeventyThreeD(name, dim);
		}

		public static Tensor SeventyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			return t;
		}
			
		public static Tensor SeventyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74);

		public static Tensor SeventyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74);
			return Tensor.SeventyFourD(name, dim);
		}

		public static Tensor SeventyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			return t;
		}
			
		public static Tensor SeventyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75);

		public static Tensor SeventyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75);
			return Tensor.SeventyFiveD(name, dim);
		}

		public static Tensor SeventyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			return t;
		}
			
		public static Tensor SeventySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76);

		public static Tensor SeventySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76);
			return Tensor.SeventySixD(name, dim);
		}

		public static Tensor SeventySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			return t;
		}
			
		public static Tensor SeventySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77);

		public static Tensor SeventySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77);
			return Tensor.SeventySevenD(name, dim);
		}

		public static Tensor SeventySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			return t;
		}
			
		public static Tensor SeventyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78);

		public static Tensor SeventyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78);
			return Tensor.SeventyEightD(name, dim);
		}

		public static Tensor SeventyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			return t;
		}
			
		public static Tensor SeventyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79);

		public static Tensor SeventyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79);
			return Tensor.SeventyNineD(name, dim);
		}

		public static Tensor SeventyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			return t;
		}
			
		public static Tensor EightyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80);

		public static Tensor EightyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80);
			return Tensor.EightyD(name, dim);
		}

		public static Tensor EightyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			return t;
		}
			
		public static Tensor EightyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81);

		public static Tensor EightyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81);
			return Tensor.EightyOneD(name, dim);
		}

		public static Tensor EightyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			return t;
		}
			
		public static Tensor EightyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82);

		public static Tensor EightyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82);
			return Tensor.EightyTwoD(name, dim);
		}

		public static Tensor EightyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81, out Index index82)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			index82 = new Index(I, 81, dim.dim82, t.GenerateName(81, indexNameBase));
			return t;
		}
			
		public static Tensor EightyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83);

		public static Tensor EightyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83);
			return Tensor.EightyThreeD(name, dim);
		}

		public static Tensor EightyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81, out Index index82, out Index index83)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			index82 = new Index(I, 81, dim.dim82, t.GenerateName(81, indexNameBase));
			index83 = new Index(I, 82, dim.dim83, t.GenerateName(82, indexNameBase));
			return t;
		}
			
		public static Tensor EightyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84);

		public static Tensor EightyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84);
			return Tensor.EightyFourD(name, dim);
		}

		public static Tensor EightyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81, out Index index82, out Index index83, out Index index84)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			index82 = new Index(I, 81, dim.dim82, t.GenerateName(81, indexNameBase));
			index83 = new Index(I, 82, dim.dim83, t.GenerateName(82, indexNameBase));
			index84 = new Index(I, 83, dim.dim84, t.GenerateName(83, indexNameBase));
			return t;
		}
			
		public static Tensor EightyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85);

		public static Tensor EightyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85);
			return Tensor.EightyFiveD(name, dim);
		}

		public static Tensor EightyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81, out Index index82, out Index index83, out Index index84, out Index index85)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			index82 = new Index(I, 81, dim.dim82, t.GenerateName(81, indexNameBase));
			index83 = new Index(I, 82, dim.dim83, t.GenerateName(82, indexNameBase));
			index84 = new Index(I, 83, dim.dim84, t.GenerateName(83, indexNameBase));
			index85 = new Index(I, 84, dim.dim85, t.GenerateName(84, indexNameBase));
			return t;
		}
			
		public static Tensor EightySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86);

		public static Tensor EightySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86);
			return Tensor.EightySixD(name, dim);
		}

		public static Tensor EightySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81, out Index index82, out Index index83, out Index index84, out Index index85, out Index index86)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			index82 = new Index(I, 81, dim.dim82, t.GenerateName(81, indexNameBase));
			index83 = new Index(I, 82, dim.dim83, t.GenerateName(82, indexNameBase));
			index84 = new Index(I, 83, dim.dim84, t.GenerateName(83, indexNameBase));
			index85 = new Index(I, 84, dim.dim85, t.GenerateName(84, indexNameBase));
			index86 = new Index(I, 85, dim.dim86, t.GenerateName(85, indexNameBase));
			return t;
		}
			
		public static Tensor EightySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87);

		public static Tensor EightySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87);
			return Tensor.EightySevenD(name, dim);
		}

		public static Tensor EightySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81, out Index index82, out Index index83, out Index index84, out Index index85, out Index index86, out Index index87)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			index82 = new Index(I, 81, dim.dim82, t.GenerateName(81, indexNameBase));
			index83 = new Index(I, 82, dim.dim83, t.GenerateName(82, indexNameBase));
			index84 = new Index(I, 83, dim.dim84, t.GenerateName(83, indexNameBase));
			index85 = new Index(I, 84, dim.dim85, t.GenerateName(84, indexNameBase));
			index86 = new Index(I, 85, dim.dim86, t.GenerateName(85, indexNameBase));
			index87 = new Index(I, 86, dim.dim87, t.GenerateName(86, indexNameBase));
			return t;
		}
			
		public static Tensor EightyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88);

		public static Tensor EightyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88);
			return Tensor.EightyEightD(name, dim);
		}

		public static Tensor EightyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81, out Index index82, out Index index83, out Index index84, out Index index85, out Index index86, out Index index87, out Index index88)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			index82 = new Index(I, 81, dim.dim82, t.GenerateName(81, indexNameBase));
			index83 = new Index(I, 82, dim.dim83, t.GenerateName(82, indexNameBase));
			index84 = new Index(I, 83, dim.dim84, t.GenerateName(83, indexNameBase));
			index85 = new Index(I, 84, dim.dim85, t.GenerateName(84, indexNameBase));
			index86 = new Index(I, 85, dim.dim86, t.GenerateName(85, indexNameBase));
			index87 = new Index(I, 86, dim.dim87, t.GenerateName(86, indexNameBase));
			index88 = new Index(I, 87, dim.dim88, t.GenerateName(87, indexNameBase));
			return t;
		}
			
		public static Tensor EightyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89);

		public static Tensor EightyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89);
			return Tensor.EightyNineD(name, dim);
		}

		public static Tensor EightyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81, out Index index82, out Index index83, out Index index84, out Index index85, out Index index86, out Index index87, out Index index88, out Index index89)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			index82 = new Index(I, 81, dim.dim82, t.GenerateName(81, indexNameBase));
			index83 = new Index(I, 82, dim.dim83, t.GenerateName(82, indexNameBase));
			index84 = new Index(I, 83, dim.dim84, t.GenerateName(83, indexNameBase));
			index85 = new Index(I, 84, dim.dim85, t.GenerateName(84, indexNameBase));
			index86 = new Index(I, 85, dim.dim86, t.GenerateName(85, indexNameBase));
			index87 = new Index(I, 86, dim.dim87, t.GenerateName(86, indexNameBase));
			index88 = new Index(I, 87, dim.dim88, t.GenerateName(87, indexNameBase));
			index89 = new Index(I, 88, dim.dim89, t.GenerateName(88, indexNameBase));
			return t;
		}
			
		public static Tensor NinetyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90);

		public static Tensor NinetyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90);
			return Tensor.NinetyD(name, dim);
		}

		public static Tensor NinetyD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81, out Index index82, out Index index83, out Index index84, out Index index85, out Index index86, out Index index87, out Index index88, out Index index89, out Index index90)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			index82 = new Index(I, 81, dim.dim82, t.GenerateName(81, indexNameBase));
			index83 = new Index(I, 82, dim.dim83, t.GenerateName(82, indexNameBase));
			index84 = new Index(I, 83, dim.dim84, t.GenerateName(83, indexNameBase));
			index85 = new Index(I, 84, dim.dim85, t.GenerateName(84, indexNameBase));
			index86 = new Index(I, 85, dim.dim86, t.GenerateName(85, indexNameBase));
			index87 = new Index(I, 86, dim.dim87, t.GenerateName(86, indexNameBase));
			index88 = new Index(I, 87, dim.dim88, t.GenerateName(87, indexNameBase));
			index89 = new Index(I, 88, dim.dim89, t.GenerateName(88, indexNameBase));
			index90 = new Index(I, 89, dim.dim90, t.GenerateName(89, indexNameBase));
			return t;
		}
			
		public static Tensor NinetyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91);

		public static Tensor NinetyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91);
			return Tensor.NinetyOneD(name, dim);
		}

		public static Tensor NinetyOneD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81, out Index index82, out Index index83, out Index index84, out Index index85, out Index index86, out Index index87, out Index index88, out Index index89, out Index index90, out Index index91)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			index82 = new Index(I, 81, dim.dim82, t.GenerateName(81, indexNameBase));
			index83 = new Index(I, 82, dim.dim83, t.GenerateName(82, indexNameBase));
			index84 = new Index(I, 83, dim.dim84, t.GenerateName(83, indexNameBase));
			index85 = new Index(I, 84, dim.dim85, t.GenerateName(84, indexNameBase));
			index86 = new Index(I, 85, dim.dim86, t.GenerateName(85, indexNameBase));
			index87 = new Index(I, 86, dim.dim87, t.GenerateName(86, indexNameBase));
			index88 = new Index(I, 87, dim.dim88, t.GenerateName(87, indexNameBase));
			index89 = new Index(I, 88, dim.dim89, t.GenerateName(88, indexNameBase));
			index90 = new Index(I, 89, dim.dim90, t.GenerateName(89, indexNameBase));
			index91 = new Index(I, 90, dim.dim91, t.GenerateName(90, indexNameBase));
			return t;
		}
			
		public static Tensor NinetyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92);

		public static Tensor NinetyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92);
			return Tensor.NinetyTwoD(name, dim);
		}

		public static Tensor NinetyTwoD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81, out Index index82, out Index index83, out Index index84, out Index index85, out Index index86, out Index index87, out Index index88, out Index index89, out Index index90, out Index index91, out Index index92)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			index82 = new Index(I, 81, dim.dim82, t.GenerateName(81, indexNameBase));
			index83 = new Index(I, 82, dim.dim83, t.GenerateName(82, indexNameBase));
			index84 = new Index(I, 83, dim.dim84, t.GenerateName(83, indexNameBase));
			index85 = new Index(I, 84, dim.dim85, t.GenerateName(84, indexNameBase));
			index86 = new Index(I, 85, dim.dim86, t.GenerateName(85, indexNameBase));
			index87 = new Index(I, 86, dim.dim87, t.GenerateName(86, indexNameBase));
			index88 = new Index(I, 87, dim.dim88, t.GenerateName(87, indexNameBase));
			index89 = new Index(I, 88, dim.dim89, t.GenerateName(88, indexNameBase));
			index90 = new Index(I, 89, dim.dim90, t.GenerateName(89, indexNameBase));
			index91 = new Index(I, 90, dim.dim91, t.GenerateName(90, indexNameBase));
			index92 = new Index(I, 91, dim.dim92, t.GenerateName(91, indexNameBase));
			return t;
		}
			
		public static Tensor NinetyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93);

		public static Tensor NinetyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93);
			return Tensor.NinetyThreeD(name, dim);
		}

		public static Tensor NinetyThreeD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81, out Index index82, out Index index83, out Index index84, out Index index85, out Index index86, out Index index87, out Index index88, out Index index89, out Index index90, out Index index91, out Index index92, out Index index93)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			index82 = new Index(I, 81, dim.dim82, t.GenerateName(81, indexNameBase));
			index83 = new Index(I, 82, dim.dim83, t.GenerateName(82, indexNameBase));
			index84 = new Index(I, 83, dim.dim84, t.GenerateName(83, indexNameBase));
			index85 = new Index(I, 84, dim.dim85, t.GenerateName(84, indexNameBase));
			index86 = new Index(I, 85, dim.dim86, t.GenerateName(85, indexNameBase));
			index87 = new Index(I, 86, dim.dim87, t.GenerateName(86, indexNameBase));
			index88 = new Index(I, 87, dim.dim88, t.GenerateName(87, indexNameBase));
			index89 = new Index(I, 88, dim.dim89, t.GenerateName(88, indexNameBase));
			index90 = new Index(I, 89, dim.dim90, t.GenerateName(89, indexNameBase));
			index91 = new Index(I, 90, dim.dim91, t.GenerateName(90, indexNameBase));
			index92 = new Index(I, 91, dim.dim92, t.GenerateName(91, indexNameBase));
			index93 = new Index(I, 92, dim.dim93, t.GenerateName(92, indexNameBase));
			return t;
		}
			
		public static Tensor NinetyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93, int dim94) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93, dim.dim94);

		public static Tensor NinetyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93, int dim94) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93, dim.dim94);
			return Tensor.NinetyFourD(name, dim);
		}

		public static Tensor NinetyFourD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93, int dim94) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81, out Index index82, out Index index83, out Index index84, out Index index85, out Index index86, out Index index87, out Index index88, out Index index89, out Index index90, out Index index91, out Index index92, out Index index93, out Index index94)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93, dim.dim94);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			index82 = new Index(I, 81, dim.dim82, t.GenerateName(81, indexNameBase));
			index83 = new Index(I, 82, dim.dim83, t.GenerateName(82, indexNameBase));
			index84 = new Index(I, 83, dim.dim84, t.GenerateName(83, indexNameBase));
			index85 = new Index(I, 84, dim.dim85, t.GenerateName(84, indexNameBase));
			index86 = new Index(I, 85, dim.dim86, t.GenerateName(85, indexNameBase));
			index87 = new Index(I, 86, dim.dim87, t.GenerateName(86, indexNameBase));
			index88 = new Index(I, 87, dim.dim88, t.GenerateName(87, indexNameBase));
			index89 = new Index(I, 88, dim.dim89, t.GenerateName(88, indexNameBase));
			index90 = new Index(I, 89, dim.dim90, t.GenerateName(89, indexNameBase));
			index91 = new Index(I, 90, dim.dim91, t.GenerateName(90, indexNameBase));
			index92 = new Index(I, 91, dim.dim92, t.GenerateName(91, indexNameBase));
			index93 = new Index(I, 92, dim.dim93, t.GenerateName(92, indexNameBase));
			index94 = new Index(I, 93, dim.dim94, t.GenerateName(93, indexNameBase));
			return t;
		}
			
		public static Tensor NinetyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93, int dim94, int dim95) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93, dim.dim94, dim.dim95);

		public static Tensor NinetyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93, int dim94, int dim95) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93, dim.dim94, dim.dim95);
			return Tensor.NinetyFiveD(name, dim);
		}

		public static Tensor NinetyFiveD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93, int dim94, int dim95) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81, out Index index82, out Index index83, out Index index84, out Index index85, out Index index86, out Index index87, out Index index88, out Index index89, out Index index90, out Index index91, out Index index92, out Index index93, out Index index94, out Index index95)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93, dim.dim94, dim.dim95);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			index82 = new Index(I, 81, dim.dim82, t.GenerateName(81, indexNameBase));
			index83 = new Index(I, 82, dim.dim83, t.GenerateName(82, indexNameBase));
			index84 = new Index(I, 83, dim.dim84, t.GenerateName(83, indexNameBase));
			index85 = new Index(I, 84, dim.dim85, t.GenerateName(84, indexNameBase));
			index86 = new Index(I, 85, dim.dim86, t.GenerateName(85, indexNameBase));
			index87 = new Index(I, 86, dim.dim87, t.GenerateName(86, indexNameBase));
			index88 = new Index(I, 87, dim.dim88, t.GenerateName(87, indexNameBase));
			index89 = new Index(I, 88, dim.dim89, t.GenerateName(88, indexNameBase));
			index90 = new Index(I, 89, dim.dim90, t.GenerateName(89, indexNameBase));
			index91 = new Index(I, 90, dim.dim91, t.GenerateName(90, indexNameBase));
			index92 = new Index(I, 91, dim.dim92, t.GenerateName(91, indexNameBase));
			index93 = new Index(I, 92, dim.dim93, t.GenerateName(92, indexNameBase));
			index94 = new Index(I, 93, dim.dim94, t.GenerateName(93, indexNameBase));
			index95 = new Index(I, 94, dim.dim95, t.GenerateName(94, indexNameBase));
			return t;
		}
			
		public static Tensor NinetySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93, int dim94, int dim95, int dim96) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93, dim.dim94, dim.dim95, dim.dim96);

		public static Tensor NinetySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93, int dim94, int dim95, int dim96) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93, dim.dim94, dim.dim95, dim.dim96);
			return Tensor.NinetySixD(name, dim);
		}

		public static Tensor NinetySixD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93, int dim94, int dim95, int dim96) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81, out Index index82, out Index index83, out Index index84, out Index index85, out Index index86, out Index index87, out Index index88, out Index index89, out Index index90, out Index index91, out Index index92, out Index index93, out Index index94, out Index index95, out Index index96)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93, dim.dim94, dim.dim95, dim.dim96);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			index82 = new Index(I, 81, dim.dim82, t.GenerateName(81, indexNameBase));
			index83 = new Index(I, 82, dim.dim83, t.GenerateName(82, indexNameBase));
			index84 = new Index(I, 83, dim.dim84, t.GenerateName(83, indexNameBase));
			index85 = new Index(I, 84, dim.dim85, t.GenerateName(84, indexNameBase));
			index86 = new Index(I, 85, dim.dim86, t.GenerateName(85, indexNameBase));
			index87 = new Index(I, 86, dim.dim87, t.GenerateName(86, indexNameBase));
			index88 = new Index(I, 87, dim.dim88, t.GenerateName(87, indexNameBase));
			index89 = new Index(I, 88, dim.dim89, t.GenerateName(88, indexNameBase));
			index90 = new Index(I, 89, dim.dim90, t.GenerateName(89, indexNameBase));
			index91 = new Index(I, 90, dim.dim91, t.GenerateName(90, indexNameBase));
			index92 = new Index(I, 91, dim.dim92, t.GenerateName(91, indexNameBase));
			index93 = new Index(I, 92, dim.dim93, t.GenerateName(92, indexNameBase));
			index94 = new Index(I, 93, dim.dim94, t.GenerateName(93, indexNameBase));
			index95 = new Index(I, 94, dim.dim95, t.GenerateName(94, indexNameBase));
			index96 = new Index(I, 95, dim.dim96, t.GenerateName(95, indexNameBase));
			return t;
		}
			
		public static Tensor NinetySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93, int dim94, int dim95, int dim96, int dim97) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93, dim.dim94, dim.dim95, dim.dim96, dim.dim97);

		public static Tensor NinetySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93, int dim94, int dim95, int dim96, int dim97) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93, dim.dim94, dim.dim95, dim.dim96, dim.dim97);
			return Tensor.NinetySevenD(name, dim);
		}

		public static Tensor NinetySevenD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93, int dim94, int dim95, int dim96, int dim97) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81, out Index index82, out Index index83, out Index index84, out Index index85, out Index index86, out Index index87, out Index index88, out Index index89, out Index index90, out Index index91, out Index index92, out Index index93, out Index index94, out Index index95, out Index index96, out Index index97)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93, dim.dim94, dim.dim95, dim.dim96, dim.dim97);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			index82 = new Index(I, 81, dim.dim82, t.GenerateName(81, indexNameBase));
			index83 = new Index(I, 82, dim.dim83, t.GenerateName(82, indexNameBase));
			index84 = new Index(I, 83, dim.dim84, t.GenerateName(83, indexNameBase));
			index85 = new Index(I, 84, dim.dim85, t.GenerateName(84, indexNameBase));
			index86 = new Index(I, 85, dim.dim86, t.GenerateName(85, indexNameBase));
			index87 = new Index(I, 86, dim.dim87, t.GenerateName(86, indexNameBase));
			index88 = new Index(I, 87, dim.dim88, t.GenerateName(87, indexNameBase));
			index89 = new Index(I, 88, dim.dim89, t.GenerateName(88, indexNameBase));
			index90 = new Index(I, 89, dim.dim90, t.GenerateName(89, indexNameBase));
			index91 = new Index(I, 90, dim.dim91, t.GenerateName(90, indexNameBase));
			index92 = new Index(I, 91, dim.dim92, t.GenerateName(91, indexNameBase));
			index93 = new Index(I, 92, dim.dim93, t.GenerateName(92, indexNameBase));
			index94 = new Index(I, 93, dim.dim94, t.GenerateName(93, indexNameBase));
			index95 = new Index(I, 94, dim.dim95, t.GenerateName(94, indexNameBase));
			index96 = new Index(I, 95, dim.dim96, t.GenerateName(95, indexNameBase));
			index97 = new Index(I, 96, dim.dim97, t.GenerateName(96, indexNameBase));
			return t;
		}
			
		public static Tensor NinetyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93, int dim94, int dim95, int dim96, int dim97, int dim98) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93, dim.dim94, dim.dim95, dim.dim96, dim.dim97, dim.dim98);

		public static Tensor NinetyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93, int dim94, int dim95, int dim96, int dim97, int dim98) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93, dim.dim94, dim.dim95, dim.dim96, dim.dim97, dim.dim98);
			return Tensor.NinetyEightD(name, dim);
		}

		public static Tensor NinetyEightD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93, int dim94, int dim95, int dim96, int dim97, int dim98) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81, out Index index82, out Index index83, out Index index84, out Index index85, out Index index86, out Index index87, out Index index88, out Index index89, out Index index90, out Index index91, out Index index92, out Index index93, out Index index94, out Index index95, out Index index96, out Index index97, out Index index98)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93, dim.dim94, dim.dim95, dim.dim96, dim.dim97, dim.dim98);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			index82 = new Index(I, 81, dim.dim82, t.GenerateName(81, indexNameBase));
			index83 = new Index(I, 82, dim.dim83, t.GenerateName(82, indexNameBase));
			index84 = new Index(I, 83, dim.dim84, t.GenerateName(83, indexNameBase));
			index85 = new Index(I, 84, dim.dim85, t.GenerateName(84, indexNameBase));
			index86 = new Index(I, 85, dim.dim86, t.GenerateName(85, indexNameBase));
			index87 = new Index(I, 86, dim.dim87, t.GenerateName(86, indexNameBase));
			index88 = new Index(I, 87, dim.dim88, t.GenerateName(87, indexNameBase));
			index89 = new Index(I, 88, dim.dim89, t.GenerateName(88, indexNameBase));
			index90 = new Index(I, 89, dim.dim90, t.GenerateName(89, indexNameBase));
			index91 = new Index(I, 90, dim.dim91, t.GenerateName(90, indexNameBase));
			index92 = new Index(I, 91, dim.dim92, t.GenerateName(91, indexNameBase));
			index93 = new Index(I, 92, dim.dim93, t.GenerateName(92, indexNameBase));
			index94 = new Index(I, 93, dim.dim94, t.GenerateName(93, indexNameBase));
			index95 = new Index(I, 94, dim.dim95, t.GenerateName(94, indexNameBase));
			index96 = new Index(I, 95, dim.dim96, t.GenerateName(95, indexNameBase));
			index97 = new Index(I, 96, dim.dim97, t.GenerateName(96, indexNameBase));
			index98 = new Index(I, 97, dim.dim98, t.GenerateName(97, indexNameBase));
			return t;
		}
			
		public static Tensor NinetyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93, int dim94, int dim95, int dim96, int dim97, int dim98, int dim99) dim) =>
			new Tensor(name, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93, dim.dim94, dim.dim95, dim.dim96, dim.dim97, dim.dim98, dim.dim99);

		public static Tensor NinetyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93, int dim94, int dim95, int dim96, int dim97, int dim98, int dim99) dim, string indexNameBase, out IndexSet I)
		{
			I = new IndexSet(indexNameBase,  dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93, dim.dim94, dim.dim95, dim.dim96, dim.dim97, dim.dim98, dim.dim99);
			return Tensor.NinetyNineD(name, dim);
		}

		public static Tensor NinetyNineD(string name, (int dim1, int dim2, int dim3, int dim4, int dim5, int dim6, int dim7, int dim8, int dim9, int dim10, int dim11, int dim12, int dim13, int dim14, int dim15, int dim16, int dim17, int dim18, int dim19, int dim20, int dim21, int dim22, int dim23, int dim24, int dim25, int dim26, int dim27, int dim28, int dim29, int dim30, int dim31, int dim32, int dim33, int dim34, int dim35, int dim36, int dim37, int dim38, int dim39, int dim40, int dim41, int dim42, int dim43, int dim44, int dim45, int dim46, int dim47, int dim48, int dim49, int dim50, int dim51, int dim52, int dim53, int dim54, int dim55, int dim56, int dim57, int dim58, int dim59, int dim60, int dim61, int dim62, int dim63, int dim64, int dim65, int dim66, int dim67, int dim68, int dim69, int dim70, int dim71, int dim72, int dim73, int dim74, int dim75, int dim76, int dim77, int dim78, int dim79, int dim80, int dim81, int dim82, int dim83, int dim84, int dim85, int dim86, int dim87, int dim88, int dim89, int dim90, int dim91, int dim92, int dim93, int dim94, int dim95, int dim96, int dim97, int dim98, int dim99) dim, string indexNameBase,
			out Index index1, out Index index2, out Index index3, out Index index4, out Index index5, out Index index6, out Index index7, out Index index8, out Index index9, out Index index10, out Index index11, out Index index12, out Index index13, out Index index14, out Index index15, out Index index16, out Index index17, out Index index18, out Index index19, out Index index20, out Index index21, out Index index22, out Index index23, out Index index24, out Index index25, out Index index26, out Index index27, out Index index28, out Index index29, out Index index30, out Index index31, out Index index32, out Index index33, out Index index34, out Index index35, out Index index36, out Index index37, out Index index38, out Index index39, out Index index40, out Index index41, out Index index42, out Index index43, out Index index44, out Index index45, out Index index46, out Index index47, out Index index48, out Index index49, out Index index50, out Index index51, out Index index52, out Index index53, out Index index54, out Index index55, out Index index56, out Index index57, out Index index58, out Index index59, out Index index60, out Index index61, out Index index62, out Index index63, out Index index64, out Index index65, out Index index66, out Index index67, out Index index68, out Index index69, out Index index70, out Index index71, out Index index72, out Index index73, out Index index74, out Index index75, out Index index76, out Index index77, out Index index78, out Index index79, out Index index80, out Index index81, out Index index82, out Index index83, out Index index84, out Index index85, out Index index86, out Index index87, out Index index88, out Index index89, out Index index90, out Index index91, out Index index92, out Index index93, out Index index94, out Index index95, out Index index96, out Index index97, out Index index98, out Index index99)
		{
			Tensor t = new Tensor(name, indexNameBase, out IndexSet I, dim.dim1, dim.dim2, dim.dim3, dim.dim4, dim.dim5, dim.dim6, dim.dim7, dim.dim8, dim.dim9, dim.dim10, dim.dim11, dim.dim12, dim.dim13, dim.dim14, dim.dim15, dim.dim16, dim.dim17, dim.dim18, dim.dim19, dim.dim20, dim.dim21, dim.dim22, dim.dim23, dim.dim24, dim.dim25, dim.dim26, dim.dim27, dim.dim28, dim.dim29, dim.dim30, dim.dim31, dim.dim32, dim.dim33, dim.dim34, dim.dim35, dim.dim36, dim.dim37, dim.dim38, dim.dim39, dim.dim40, dim.dim41, dim.dim42, dim.dim43, dim.dim44, dim.dim45, dim.dim46, dim.dim47, dim.dim48, dim.dim49, dim.dim50, dim.dim51, dim.dim52, dim.dim53, dim.dim54, dim.dim55, dim.dim56, dim.dim57, dim.dim58, dim.dim59, dim.dim60, dim.dim61, dim.dim62, dim.dim63, dim.dim64, dim.dim65, dim.dim66, dim.dim67, dim.dim68, dim.dim69, dim.dim70, dim.dim71, dim.dim72, dim.dim73, dim.dim74, dim.dim75, dim.dim76, dim.dim77, dim.dim78, dim.dim79, dim.dim80, dim.dim81, dim.dim82, dim.dim83, dim.dim84, dim.dim85, dim.dim86, dim.dim87, dim.dim88, dim.dim89, dim.dim90, dim.dim91, dim.dim92, dim.dim93, dim.dim94, dim.dim95, dim.dim96, dim.dim97, dim.dim98, dim.dim99);
			index1 = new Index(I, 0, dim.dim1, t.GenerateName(0, indexNameBase));
			index2 = new Index(I, 1, dim.dim2, t.GenerateName(1, indexNameBase));
			index3 = new Index(I, 2, dim.dim3, t.GenerateName(2, indexNameBase));
			index4 = new Index(I, 3, dim.dim4, t.GenerateName(3, indexNameBase));
			index5 = new Index(I, 4, dim.dim5, t.GenerateName(4, indexNameBase));
			index6 = new Index(I, 5, dim.dim6, t.GenerateName(5, indexNameBase));
			index7 = new Index(I, 6, dim.dim7, t.GenerateName(6, indexNameBase));
			index8 = new Index(I, 7, dim.dim8, t.GenerateName(7, indexNameBase));
			index9 = new Index(I, 8, dim.dim9, t.GenerateName(8, indexNameBase));
			index10 = new Index(I, 9, dim.dim10, t.GenerateName(9, indexNameBase));
			index11 = new Index(I, 10, dim.dim11, t.GenerateName(10, indexNameBase));
			index12 = new Index(I, 11, dim.dim12, t.GenerateName(11, indexNameBase));
			index13 = new Index(I, 12, dim.dim13, t.GenerateName(12, indexNameBase));
			index14 = new Index(I, 13, dim.dim14, t.GenerateName(13, indexNameBase));
			index15 = new Index(I, 14, dim.dim15, t.GenerateName(14, indexNameBase));
			index16 = new Index(I, 15, dim.dim16, t.GenerateName(15, indexNameBase));
			index17 = new Index(I, 16, dim.dim17, t.GenerateName(16, indexNameBase));
			index18 = new Index(I, 17, dim.dim18, t.GenerateName(17, indexNameBase));
			index19 = new Index(I, 18, dim.dim19, t.GenerateName(18, indexNameBase));
			index20 = new Index(I, 19, dim.dim20, t.GenerateName(19, indexNameBase));
			index21 = new Index(I, 20, dim.dim21, t.GenerateName(20, indexNameBase));
			index22 = new Index(I, 21, dim.dim22, t.GenerateName(21, indexNameBase));
			index23 = new Index(I, 22, dim.dim23, t.GenerateName(22, indexNameBase));
			index24 = new Index(I, 23, dim.dim24, t.GenerateName(23, indexNameBase));
			index25 = new Index(I, 24, dim.dim25, t.GenerateName(24, indexNameBase));
			index26 = new Index(I, 25, dim.dim26, t.GenerateName(25, indexNameBase));
			index27 = new Index(I, 26, dim.dim27, t.GenerateName(26, indexNameBase));
			index28 = new Index(I, 27, dim.dim28, t.GenerateName(27, indexNameBase));
			index29 = new Index(I, 28, dim.dim29, t.GenerateName(28, indexNameBase));
			index30 = new Index(I, 29, dim.dim30, t.GenerateName(29, indexNameBase));
			index31 = new Index(I, 30, dim.dim31, t.GenerateName(30, indexNameBase));
			index32 = new Index(I, 31, dim.dim32, t.GenerateName(31, indexNameBase));
			index33 = new Index(I, 32, dim.dim33, t.GenerateName(32, indexNameBase));
			index34 = new Index(I, 33, dim.dim34, t.GenerateName(33, indexNameBase));
			index35 = new Index(I, 34, dim.dim35, t.GenerateName(34, indexNameBase));
			index36 = new Index(I, 35, dim.dim36, t.GenerateName(35, indexNameBase));
			index37 = new Index(I, 36, dim.dim37, t.GenerateName(36, indexNameBase));
			index38 = new Index(I, 37, dim.dim38, t.GenerateName(37, indexNameBase));
			index39 = new Index(I, 38, dim.dim39, t.GenerateName(38, indexNameBase));
			index40 = new Index(I, 39, dim.dim40, t.GenerateName(39, indexNameBase));
			index41 = new Index(I, 40, dim.dim41, t.GenerateName(40, indexNameBase));
			index42 = new Index(I, 41, dim.dim42, t.GenerateName(41, indexNameBase));
			index43 = new Index(I, 42, dim.dim43, t.GenerateName(42, indexNameBase));
			index44 = new Index(I, 43, dim.dim44, t.GenerateName(43, indexNameBase));
			index45 = new Index(I, 44, dim.dim45, t.GenerateName(44, indexNameBase));
			index46 = new Index(I, 45, dim.dim46, t.GenerateName(45, indexNameBase));
			index47 = new Index(I, 46, dim.dim47, t.GenerateName(46, indexNameBase));
			index48 = new Index(I, 47, dim.dim48, t.GenerateName(47, indexNameBase));
			index49 = new Index(I, 48, dim.dim49, t.GenerateName(48, indexNameBase));
			index50 = new Index(I, 49, dim.dim50, t.GenerateName(49, indexNameBase));
			index51 = new Index(I, 50, dim.dim51, t.GenerateName(50, indexNameBase));
			index52 = new Index(I, 51, dim.dim52, t.GenerateName(51, indexNameBase));
			index53 = new Index(I, 52, dim.dim53, t.GenerateName(52, indexNameBase));
			index54 = new Index(I, 53, dim.dim54, t.GenerateName(53, indexNameBase));
			index55 = new Index(I, 54, dim.dim55, t.GenerateName(54, indexNameBase));
			index56 = new Index(I, 55, dim.dim56, t.GenerateName(55, indexNameBase));
			index57 = new Index(I, 56, dim.dim57, t.GenerateName(56, indexNameBase));
			index58 = new Index(I, 57, dim.dim58, t.GenerateName(57, indexNameBase));
			index59 = new Index(I, 58, dim.dim59, t.GenerateName(58, indexNameBase));
			index60 = new Index(I, 59, dim.dim60, t.GenerateName(59, indexNameBase));
			index61 = new Index(I, 60, dim.dim61, t.GenerateName(60, indexNameBase));
			index62 = new Index(I, 61, dim.dim62, t.GenerateName(61, indexNameBase));
			index63 = new Index(I, 62, dim.dim63, t.GenerateName(62, indexNameBase));
			index64 = new Index(I, 63, dim.dim64, t.GenerateName(63, indexNameBase));
			index65 = new Index(I, 64, dim.dim65, t.GenerateName(64, indexNameBase));
			index66 = new Index(I, 65, dim.dim66, t.GenerateName(65, indexNameBase));
			index67 = new Index(I, 66, dim.dim67, t.GenerateName(66, indexNameBase));
			index68 = new Index(I, 67, dim.dim68, t.GenerateName(67, indexNameBase));
			index69 = new Index(I, 68, dim.dim69, t.GenerateName(68, indexNameBase));
			index70 = new Index(I, 69, dim.dim70, t.GenerateName(69, indexNameBase));
			index71 = new Index(I, 70, dim.dim71, t.GenerateName(70, indexNameBase));
			index72 = new Index(I, 71, dim.dim72, t.GenerateName(71, indexNameBase));
			index73 = new Index(I, 72, dim.dim73, t.GenerateName(72, indexNameBase));
			index74 = new Index(I, 73, dim.dim74, t.GenerateName(73, indexNameBase));
			index75 = new Index(I, 74, dim.dim75, t.GenerateName(74, indexNameBase));
			index76 = new Index(I, 75, dim.dim76, t.GenerateName(75, indexNameBase));
			index77 = new Index(I, 76, dim.dim77, t.GenerateName(76, indexNameBase));
			index78 = new Index(I, 77, dim.dim78, t.GenerateName(77, indexNameBase));
			index79 = new Index(I, 78, dim.dim79, t.GenerateName(78, indexNameBase));
			index80 = new Index(I, 79, dim.dim80, t.GenerateName(79, indexNameBase));
			index81 = new Index(I, 80, dim.dim81, t.GenerateName(80, indexNameBase));
			index82 = new Index(I, 81, dim.dim82, t.GenerateName(81, indexNameBase));
			index83 = new Index(I, 82, dim.dim83, t.GenerateName(82, indexNameBase));
			index84 = new Index(I, 83, dim.dim84, t.GenerateName(83, indexNameBase));
			index85 = new Index(I, 84, dim.dim85, t.GenerateName(84, indexNameBase));
			index86 = new Index(I, 85, dim.dim86, t.GenerateName(85, indexNameBase));
			index87 = new Index(I, 86, dim.dim87, t.GenerateName(86, indexNameBase));
			index88 = new Index(I, 87, dim.dim88, t.GenerateName(87, indexNameBase));
			index89 = new Index(I, 88, dim.dim89, t.GenerateName(88, indexNameBase));
			index90 = new Index(I, 89, dim.dim90, t.GenerateName(89, indexNameBase));
			index91 = new Index(I, 90, dim.dim91, t.GenerateName(90, indexNameBase));
			index92 = new Index(I, 91, dim.dim92, t.GenerateName(91, indexNameBase));
			index93 = new Index(I, 92, dim.dim93, t.GenerateName(92, indexNameBase));
			index94 = new Index(I, 93, dim.dim94, t.GenerateName(93, indexNameBase));
			index95 = new Index(I, 94, dim.dim95, t.GenerateName(94, indexNameBase));
			index96 = new Index(I, 95, dim.dim96, t.GenerateName(95, indexNameBase));
			index97 = new Index(I, 96, dim.dim97, t.GenerateName(96, indexNameBase));
			index98 = new Index(I, 97, dim.dim98, t.GenerateName(97, indexNameBase));
			index99 = new Index(I, 98, dim.dim99, t.GenerateName(98, indexNameBase));
			return t;
		}
		}
}