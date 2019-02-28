using UnityEngine;
public interface IHaveAnimation{
    Animator animator { get; set; }
    void PlayAnimation();
}