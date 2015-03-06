﻿using Android.Support.V7.Widget;
using Android.Views;


namespace GridViewInfiniteScroll
{
  public class MyRecyclerAdapter : RecyclerView.Adapter
  {
    private readonly MySimpleItemLoader _mySimpleItemLoader;

    public MyRecyclerAdapter(MySimpleItemLoader mySimpleItemLoader)
    {
      _mySimpleItemLoader = mySimpleItemLoader;
    }

    public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
    {
      throw new System.NotImplementedException();
    }

    /// <summary>
    /// This lets you look at the viewType value you set in the  GetItemViewType
    /// method, and use that to determine what kind of viewholder you want to create.
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="viewType"></param>
    /// <returns></returns>
    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    {
      var layoutInflater = LayoutInflater.From(parent.Context);

      switch (viewType)
      {
        case 0:
          {
            var view = layoutInflater.Inflate(Resource.Layout.MyGridViewCell, parent, false);
            var viewHolder = new MySimpleItemViewHolder(view);
            return viewHolder;
          }
        default:
          {
            return null; // this may cause you to crash if there's a type in your list you forgot about...
          }
      }
    }

    /// <summary>
    /// Manually added this override, you'll need it if you have different types. The integer value
    /// you return can be anything you like, you just have to cater for it in 'OnCreateViewHolder' 
    /// to make  sure you create the right kind of viewholder for the item type.
    /// of items in your list
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public override int GetItemViewType(int position)
    {
      if (_mySimpleItemLoader.MySimpleItems[position].GetType() == typeof(MySimpleItem))
      {
        return 0;
      }
      return 0;
    }

    public override int ItemCount
    {
      get { return this._mySimpleItemLoader.MySimpleItems.Count; }
    }
  }
}